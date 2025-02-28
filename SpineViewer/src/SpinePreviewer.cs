using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Policy;
using System.Diagnostics;
using NLog.Targets;

namespace SpineViewer
{
    public partial class SpinePreviewer : UserControl
    {
        /// <summary>
        /// 包装类, 用于 PropertyGrid 显示
        /// </summary>
        private class PreviewerProperty
        {
            private readonly SpinePreviewer previewer;

            public PreviewerProperty(SpinePreviewer previewer) { this.previewer = previewer; }

            /// <summary>
            /// 导出画面分辨率
            /// </summary>
            [TypeConverter(typeof(SizeTypeConverter))]
            [Category("属性"), DisplayName("分辨率")]
            public Size Resolution { get => previewer.Resolution; set => previewer.Resolution = value; }

            [TypeConverter(typeof(PointFTypeConverter))]
            [Category("属性"), DisplayName("画面中心点")]
            public PointF Center { get => previewer.Center; set => previewer.Center = value; }

            /// <summary>
            /// 画面缩放
            /// </summary>
            [Category("属性"), DisplayName("缩放")]
            public float Zoom { get => previewer.Zoom; set => previewer.Zoom = value; }

            /// <summary>
            /// 画面旋转
            /// </summary>
            [Category("属性"), DisplayName("旋转")]
            public float Rotation { get => previewer.Rotation; set => previewer.Rotation = value; }

            /// <summary>
            /// 画面旋转
            /// </summary>
            [Category("属性"), DisplayName("水平翻转")]
            public bool FlipX { get => previewer.FlipX; set => previewer.FlipX = value; }

            /// <summary>
            /// 画面旋转
            /// </summary>
            [Category("属性"), DisplayName("垂直翻转")]
            public bool FlipY { get => previewer.FlipY; set => previewer.FlipY = value; }
        }

        [Category("自定义"), Description("相关联的 SpineListView")]
        public SpineListView? SpineListView { get; set; }

        [Category("自定义"), Description("用于显示画面属性的属性页")]
        public PropertyGrid? PropertyGrid
        {
            get => propertyGrid;
            set
            {
                propertyGrid = value;
                if (propertyGrid is not null)
                    propertyGrid.SelectedObject = new PreviewerProperty(this);
            }
        }
        private PropertyGrid? propertyGrid;

        public const float ZOOM_MAX = 1000f;
        public const float ZOOM_MIN = 0.001f;

        private readonly SFML.Graphics.RenderWindow RenderWindow;
        private readonly SFML.System.Clock Clock = new();
        private readonly SFML.Graphics.Color BackgroundColor = SFML.Graphics.Color.Green;

        private SFML.System.Vector2f? draggingSrc = null;
        private Spine.Spine? draggingSpine = null;

        /// <summary>
        /// 安全获取 Spine 列表
        /// </summary>
        private Spine.Spine[] Spines
        {
            get
            {
                if (SpineListView is null)
                    return [];

                // 需要在控件线程拿到数组浅拷贝副本
                Spine.Spine[] spines = null;
                if (SpineListView.InvokeRequired)
                    SpineListView.Invoke(() => spines = SpineListView.Spines.ToArray());
                else
                    spines = SpineListView.Spines.ToArray();
                return spines;
            }
        }

        public SpinePreviewer()
        {
            InitializeComponent();
            RenderWindow = new(panel.Handle);
            RenderWindow.SetFramerateLimit(30);
            RenderWindow.SetActive(false);
            Resolution = new(1280, 720);
            Center = new(0, 0);
            FlipY = true;
        }

        /// <summary>
        /// 分辨率
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Size Resolution
        {
            get => resolution;
            set
            {
                if (value.Width <= 0) value.Width = 100;
                if (value.Height <= 0) value.Height = 100;

                float parentX = Width;
                float parentY = Height;
                float sizeX = value.Width;
                float sizeY = value.Height;

                if ((sizeY / sizeX) < (parentY / parentX))
                {
                    // 相同的 X, 子窗口 Y 更小
                    sizeY = parentX * sizeY / sizeX;
                    sizeX = parentX;
                }
                else
                {
                    // 相同的 Y, 子窗口 X 更小
                    sizeX = parentY * sizeX / sizeY;
                    sizeY = parentY;
                }

                // 必须通过 SFML 的方法调整窗口
                RenderWindow.Position = new((int)(parentX - sizeX) / 2, (int)(parentY - sizeY) / 2);
                RenderWindow.Size = new((uint)sizeX, (uint)sizeY);

                // 将 view 的大小设置成于 resolution 相同的大小, 其余属性都不变
                var view = RenderWindow.GetView();
                var signX = Math.Sign(view.Size.X);
                var signY = Math.Sign(view.Size.Y);
                view.Size = new(value.Width * signX, value.Height * signY);
                RenderWindow.SetView(view);

                resolution = value;
            }
        }
        private Size resolution = new(0, 0);

        /// <summary>
        /// 画面中心点
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public PointF Center
        {
            get
            {
                var center = RenderWindow.GetView().Center;
                return new(center.X, center.Y);
            }
            set
            {
                var view = RenderWindow.GetView();
                view.Center = new(value.X, value.Y);
                RenderWindow.SetView(view);
            }
        }

        /// <summary>
        /// 画面缩放
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public float Zoom
        {
            get => resolution.Width / Math.Abs(RenderWindow.GetView().Size.X);
            set
            {
                value = Math.Clamp(value, ZOOM_MIN, ZOOM_MAX);
                var view = RenderWindow.GetView();
                var signX = Math.Sign(view.Size.X);
                var signY = Math.Sign(view.Size.Y);
                view.Size = new(resolution.Width / value * signX, resolution.Height / value * signY);
                RenderWindow.SetView(view);
            }
        }

        /// <summary>
        /// 画面旋转
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public float Rotation
        {
            get => RenderWindow.GetView().Rotation;
            set
            {
                var view = RenderWindow.GetView();
                view.Rotation = value;
                RenderWindow.SetView(view);
            }
        }

        /// <summary>
        /// 水平翻转
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool FlipX
        {
            get => RenderWindow.GetView().Size.X < 0;
            set
            {
                var view = RenderWindow.GetView();
                var size = view.Size;
                if (size.X > 0 && value || size.X < 0 && !value)
                    size.X *= -1;
                view.Size = size;
                RenderWindow.SetView(view);
            }
        }

        /// <summary>
        /// 垂直翻转
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public bool FlipY
        {
            get => RenderWindow.GetView().Size.Y < 0;
            set
            {
                var view = RenderWindow.GetView();
                var size = view.Size;
                if (size.Y > 0 && value || size.Y < 0 && !value)
                    size.Y *= -1;
                view.Size = size;
                RenderWindow.SetView(view);
            }
        }

        /// <summary>
        /// 开始预览
        /// </summary>
        public void StartPreview()
        {
            if (!backgroundWorker.IsBusy)
                backgroundWorker.RunWorkerAsync();
        }

        /// <summary>
        /// 停止预览
        /// </summary>
        public void StopPreview()
        {
            if (backgroundWorker.IsBusy)
                backgroundWorker.CancelAsync();
        }

        private void SpinePreviewer_SizeChanged(object sender, EventArgs e)
        {
            if (RenderWindow is null)
                return;

            float parentX = Width;
            float parentY = Height;
            float sizeX = panel.Width;
            float sizeY = panel.Height;

            if ((sizeY / sizeX) < (parentY / parentX))
            {
                // 相同的 X, 子窗口 Y 更小
                sizeY = parentX * sizeY / sizeX;
                sizeX = parentX;
            }
            else
            {
                // 相同的 Y, 子窗口 X 更小
                sizeX = parentY * sizeX / sizeY;
                sizeY = parentY;
            }

            // 必须通过 SFML 的方法调整窗口
            RenderWindow.Position = new((int)(parentX - sizeX) / 2, (int)(parentY - sizeY) / 2);
            RenderWindow.Size = new((uint)sizeX, (uint)sizeY);
        }

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            // 右键优先级高, 进入画面拖动模式, 需要重新记录源点
            if ((e.Button & MouseButtons.Right) != 0)
            {
                draggingSpine = null;
                draggingSrc = RenderWindow.MapPixelToCoords(new(e.X, e.Y));
                Cursor = Cursors.Hand;
            }
            // 按下了左键并且右键是松开的
            else if ((e.Button & MouseButtons.Left) != 0 && (MouseButtons & MouseButtons.Right) == 0)
            {
                draggingSrc = RenderWindow.MapPixelToCoords(new(e.X, e.Y));
                var src = new PointF(((SFML.System.Vector2f)draggingSrc).X, ((SFML.System.Vector2f)draggingSrc).Y);
                foreach (var spine in Spines)
                {
                    if (spine.Bounds.Contains(src))
                    {
                        draggingSpine = spine;
                        break;
                    }
                }
            }
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (draggingSrc is null)
                return;

            var src = (SFML.System.Vector2f)draggingSrc;
            var dst = RenderWindow.MapPixelToCoords(new(e.X, e.Y));
            var _delta = dst - src;
            var delta = new SizeF(_delta.X, _delta.Y);

            if ((e.Button & MouseButtons.Right) != 0)
            {
                Center -= delta;
            }
            else if ((e.Button & MouseButtons.Left) != 0)
            {
                if (draggingSpine is not null)
                    draggingSpine.Position += delta;
                draggingSrc = dst;
            }
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            // 右键高优先级, 结束画面拖动模式
            if ((e.Button & MouseButtons.Right) != 0)
            {
                draggingSpine = null;
                SpineListView?.PropertyGrid?.Refresh(); // 面板刷新不能放在 Move 事件里, 会导致一直在 Move

                draggingSrc = null;
                Cursor = Cursors.Default;
                PropertyGrid?.Refresh();
            }
            // 按下了左键并且右键是松开的
            else if ((e.Button & MouseButtons.Left) != 0 && (MouseButtons & MouseButtons.Right) == 0)
            {
                draggingSrc = null;
                draggingSpine = null;
                SpineListView?.PropertyGrid?.Refresh();
            }
        }

        private void panel_MouseWheel(object sender, MouseEventArgs e)
        {
            Zoom *= (e.Delta > 0 ? 1.1f : 0.9f);
            PropertyGrid?.Refresh();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            RenderWindow.SetActive(true);
            float delta;

            while (!backgroundWorker.CancellationPending)
            {
                delta = Clock.ElapsedTime.AsSeconds();
                Clock.Restart();

                // TODO: 绘制网格线
                RenderWindow.Clear(BackgroundColor);

                foreach (var spine in Spines.Reverse())
                {
                    spine.Update(delta);
                    RenderWindow.Draw(spine);
                }

                RenderWindow.Display();
            }

            RenderWindow.SetActive(false);
        }
    }

}
