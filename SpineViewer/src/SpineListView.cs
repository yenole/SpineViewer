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
using System.Diagnostics;

namespace SpineViewer
{
    public partial class SpineListView : UserControl
    {
        [Category("自定义"), Description("用于显示骨骼属性的属性页")]
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
        /// 弹出添加对话框在指定位置之前插入一项
        /// </summary>
        private void Insert(int index = -1)
        {
            // 如果索引无效则插在末尾
            if (index < 0 || index > spines.Count)
                index = spines.Count;

            var dialog = new OpenSpineDialog();
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var spine = Spine.Spine.New(dialog.Version, dialog.SkelPath, dialog.AtlasPath);
                spines.Insert(index, spine);
                listView.Items.Insert(index, new ListViewItem([spine.Name, spine.Version.String()], -1) { ToolTipText = spine.SkelPath });
            }
            catch (Exception ex)
            {
                Program.Logger.Error(ex.ToString());
                Program.Logger.Error("Failed to load {} {}", dialog.SkelPath, dialog.AtlasPath);
                MessageBox.Show(ex.ToString(), "骨骼加载失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 弹出添加对话框
        /// </summary>
        public void Add() 
        { 
            Insert(); 
        }

        /// <summary>
        /// 弹出批量添加对话框
        /// </summary>
        public void BatchAdd()
        {
            var openDialog = new BatchOpenSpineDialog();
            if (openDialog.ShowDialog() != DialogResult.OK)
                return;

            var progressDialog = new ProgressDialog();
            progressDialog.DoWork += BatchAdd_Work;
            progressDialog.RunWorkerAsync(new { openDialog.SkelPaths, openDialog.Version });
            progressDialog.ShowDialog();
        }

        private void BatchAdd_Work(object? sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            var arguments = e.Argument as dynamic;
            var skelPaths = arguments.SkelPaths as string[];
            var version = (Spine.Version)arguments.Version;

            int totalCount = skelPaths.Length;
            int success = 0;
            int error = 0;

            for (int i = 0; i < totalCount; i++)
            {
                if (worker.CancellationPending)
                    break;

                var skelPath = skelPaths[i];

                worker.ReportProgress((int)((i + 1) * 100.0) / totalCount, $"正在处理 {i + 1}/{totalCount}");
                try
                {
                    var spine = Spine.Spine.New(version, skelPath);
                    // 对 spines 和 Items 的操作都要转到窗口线程操作
                    if (listView.InvokeRequired)
                    {
                        listView.Invoke(() =>
                        {
                            spines.Add(spine);
                            listView.Items.Add(new ListViewItem([spine.Name, spine.Version.String()], -1) { ToolTipText = spine.SkelPath });
                        });
                    }
                    else
                    {
                        spines.Add(spine);
                        listView.Items.Add(new ListViewItem([spine.Name, spine.Version.String()], -1) { ToolTipText = spine.SkelPath });
                    }
                    success++;
                }
                catch (Exception ex)
                {
                    Program.Logger.Error(ex.ToString());
                    Program.Logger.Error("Failed to load {}", skelPath);
                    error++;
                }
            }

            if (error > 0)
            {
                Program.Logger.Warn("Batch load {} successfully, {} failed", success, error);
            }
            else
            {
                Program.Logger.Info("{} skel loaded successfully", success);
            }
        }

        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PropertyGrid is not null)
            {

                if (listView.SelectedIndices.Count <= 0)
                    PropertyGrid.SelectedObject = null;
                else if (listView.SelectedIndices.Count <= 1)
                    PropertyGrid.SelectedObject = spines[listView.SelectedIndices[0]];
                else
                    PropertyGrid.SelectedObjects = listView.SelectedIndices.Cast<int>().Select(index => spines[index]).ToArray();
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

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            var selectedCount = listView.SelectedIndices.Count;
            var itemsCount = listView.Items.Count;
            toolStripMenuItem_Insert.Enabled = selectedCount == 1;
            toolStripMenuItem_Remove.Enabled = selectedCount >= 1;
            toolStripMenuItem_RemoveAll.Enabled = itemsCount > 0;
        }

        private void toolStripMenuItem_Add_Click(object sender, EventArgs e)
        {
            Insert();
        }

        private void toolStripMenuItem_BatchAdd_Click(object sender, EventArgs e)
        {
            BatchAdd();
        }

        private void toolStripMenuItem_Insert_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count == 1)
                Insert(listView.SelectedIndices[0]);
        }

        private void toolStripMenuItem_Remove_Click(object sender, EventArgs e)
        {
            if (listView.SelectedIndices.Count <= 0)
                return;

            if (listView.SelectedIndices.Count > 1)
            {
                if (MessageBox.Show($"确定移除所选 {listView.SelectedIndices.Count} 项？", "操作确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
                {
                    return;
                }
            }

            foreach (var i in listView.SelectedIndices.Cast<int>().OrderByDescending(x => x))
            {
                spines.RemoveAt(i);
                listView.Items.RemoveAt(i);
            }
        }

        private void toolStripMenuItem_RemoveAll_Click(object sender, EventArgs e)
        {
            if (listView.Items.Count <= 0)
                return;

            if (MessageBox.Show("确认移除所有项吗？", "操作确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                spines.Clear();
                listView.Items.Clear();
                if (PropertyGrid is not null) 
                    PropertyGrid.SelectedObject = null;
            }
        }
    }
}
