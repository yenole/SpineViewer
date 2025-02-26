using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;
using SpineViewer.Spine;
using System.Reflection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Diagnostics;

namespace SpineViewer
{
    public partial class SpineListView : UserControl
    {
        [Browsable(true), Category("自定义"), Description("用于显示骨骼属性的属性页")]
        public PropertyGrid? PropertyGrid { get; set; }

        /// <summary>
        /// Spine 列表
        /// </summary>
        [Browsable(false)]
        public ReadOnlyCollection<Spine.Spine> Spines { get => spines.AsReadOnly(); }
        private readonly List<Spine.Spine> spines = [];

        public SpineListView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 弹出添加对话框
        /// </summary>
        public void Add()
        {
            var dialog = new OpenSpineDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var spine = Spine.Spine.New(dialog.Version, dialog.SkelPath, dialog.AtlasPath);
                    spines.Add(spine);
                    listView.Items.Add(new ListViewItem([spine.Name, spine.Version.String()], -1) { ToolTipText = spine.SkelPath });
                }
                catch (Exception ex)
                {
                    Program.Logger.Error(ex.ToString());
                    Program.Logger.Error($"Failed to load {dialog.SkelPath} {dialog.AtlasPath}");
                    MessageBox.Show(ex.ToString(), "骨骼加载失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// 弹出批量添加对话框
        /// </summary>
        public void BatchAdd()
        {
            throw new NotImplementedException();
        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            Add();
        }

        private void button_Insert_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count <= 0)
                return;

            var index = listView.SelectedIndices[0];
            var dialog = new OpenSpineDialog();
            dialog.ShowDialog();
            try
            {
                var spine = Spine.Spine.New(dialog.Version, dialog.SkelPath, dialog.AtlasPath);
                spines.Insert(index, spine);
                listView.Items.Insert(index, new ListViewItem([spine.Name, spine.Version.String()], -1) { ToolTipText = spine.SkelPath });
            }
            catch (Exception ex)
            {
                Program.Logger.Error(ex.ToString());
                Program.Logger.Error($"Failed to load {dialog.SkelPath} {dialog.AtlasPath}");
                MessageBox.Show(ex.ToString(), "骨骼加载失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count <= 0)
                return;

            foreach (var i in listView.SelectedIndices.Cast<int>().OrderByDescending(x => x))
            {
                spines.RemoveAt(i);
                listView.Items.RemoveAt(i);
            }
        }

        private void button_MoveUp_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count <= 0)
                return;

            var index = listView.SelectedIndices[0];
            if (index > 0)
            {
                (spines[index - 1], spines[index]) = (spines[index], spines[index - 1]);
                var item = listView.Items[index];
                listView.Items.RemoveAt(index);
                listView.Items.Insert(index - 1, item);
            }
        }

        private void button_MoveDown_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count <= 0)
                return;

            var index = listView.SelectedIndices[0];
            if (index < spines.Count - 1)
            {
                (spines[index], spines[index + 1]) = (spines[index + 1], spines[index]);
                var item = listView.Items[index + 1];
                listView.Items.RemoveAt(index + 1);
                listView.Items.Insert(index, item);
            }
        }

        private void button_RemoveAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认移除所有项吗？", "操作确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                spines.Clear();
                listView.Items.Clear();
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count <= 0)
            {
                button_Insert.Enabled = false;
                button_Remove.Enabled = false;
                button_MoveUp.Enabled = false;
                button_MoveDown.Enabled = false;
                if (PropertyGrid is not null)
                    PropertyGrid.SelectedObject = null;
            }
            else if (listView.SelectedIndices.Count <= 1)
            {
                button_Insert.Enabled = true;
                button_Remove.Enabled = true;
                button_MoveUp.Enabled = true;
                button_MoveDown.Enabled = true;
                if (PropertyGrid is not null)
                    PropertyGrid.SelectedObject = spines[listView.SelectedIndices[0]];
            }
            else
            {
                button_Insert.Enabled = false;
                button_Remove.Enabled = true;
                button_MoveUp.Enabled = false;
                button_MoveDown.Enabled = false;
                if (PropertyGrid is not null)
                    PropertyGrid.SelectedObject = null;
            }
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                listView.BeginUpdate();
                foreach (ListViewItem item in listView.Items)
                {
                    item.Selected = true;
                }
                listView.EndUpdate();
            }
        }

        private void listView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void listView_DragOver(object sender, DragEventArgs e)
        {
            // 检查拖放目标是否有效
            e.Effect = DragDropEffects.Move;

            // 获取鼠标位置并确定目标索引
            var point = listView.PointToClient(new(e.X, e.Y));
            var targetItem = listView.GetItemAt(point.X, point.Y);

            // 高亮目标项
            if (targetItem != null)
            {
                foreach (ListViewItem item in listView.Items)
                {
                    item.BackColor = listView.BackColor;
                }
                targetItem.BackColor = Color.LightGray;
            }
        }

        private void listView_DragDrop(object sender, DragEventArgs e)
        {
            // 获取拖放源项和目标项
            var draggedItem = (ListViewItem)e.Data.GetData(typeof(ListViewItem));
            int draggedIndex = draggedItem.Index;
            var draggedSpine = spines[draggedIndex];

            var point = listView.PointToClient(new Point(e.X, e.Y));
            var targetItem = listView.GetItemAt(point.X, point.Y);
            int targetIndex = targetItem is null ? listView.Items.Count : targetItem.Index;

            if (targetIndex <= draggedIndex)
            {
                spines.RemoveAt(draggedIndex);
                spines.Insert(targetIndex, draggedSpine);
                listView.Items.RemoveAt(draggedIndex);
                listView.Items.Insert(targetIndex, draggedItem);
            }
            else
            {
                spines.RemoveAt(draggedIndex);
                spines.Insert(targetIndex - 1, draggedSpine);
                listView.Items.RemoveAt(draggedIndex);
                listView.Items.Insert(targetIndex - 1, draggedItem);
            }

            // 重置背景颜色
            foreach (ListViewItem item in listView.Items)
            {
                item.BackColor = listView.BackColor;
            }
        }
    }
}
