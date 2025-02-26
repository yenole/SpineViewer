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
using SpineViewer.src;

namespace SpineViewer
{
    public partial class ListViewSkel : UserControl
    {
        [Browsable(true), Category("自定义"), Description("用于显示骨骼属性的属性页")]
        public PropertyGrid? PropertyGrid { get; set; }

        /// <summary>
        /// Spine 列表
        /// </summary>
        [Browsable(false)]
        public ReadOnlyCollection<Spine.Spine> Spines { get => spines.AsReadOnly(); }
        private readonly List<Spine.Spine> spines = [];

        public ListViewSkel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 弹出添加对话框
        /// </summary>
        public void Add()
        {
            var dialog = new SkelSelectDialog();
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
            var dialog = new SkelSelectDialog();
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
    }
}
