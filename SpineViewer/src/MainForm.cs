using NLog;
using SpineViewer.Spine;
using System.ComponentModel;
using System.Diagnostics;

namespace SpineViewer
{
    public partial class MainForm : Form
    {
        Manager spineManger = null;

        public MainForm()
        {
            InitializeComponent();
            InitializeLogConfiguration();

            spineManger = new(listView_SkelList);
        }

        /// <summary>
        /// 初始化窗口日志器
        /// </summary>
        private void InitializeLogConfiguration()
        {
            // 窗口日志
            var rtbTarget = new NLog.Windows.Forms.RichTextBoxTarget
            {
                Name = "rtbTarget",
                TargetForm = this,
                TargetRichTextBox = rtbLog,
                AutoScroll = true,
                MaxLines = 3000,
                SupportLinks = true,
                Layout = "[${level:format=OneLetter}]${date:format=yyyy-MM-dd HH\\:mm\\:ss} - ${message}"
            };

            rtbTarget.WordColoringRules.Add(new("[D]", "Gray", "Empty", FontStyle.Bold));
            rtbTarget.WordColoringRules.Add(new("[I]", "Gray", "Empty", FontStyle.Bold));
            rtbTarget.WordColoringRules.Add(new("[W]", "DarkOrange", "Empty", FontStyle.Bold));
            rtbTarget.WordColoringRules.Add(new("[E]", "Red", "Empty", FontStyle.Bold));
            rtbTarget.WordColoringRules.Add(new("[F]", "Red", "Empty", FontStyle.Bold));

            LogManager.Configuration.AddTarget(rtbTarget);
            LogManager.Configuration.AddRule(LogLevel.Debug, LogLevel.Fatal, rtbTarget);
            LogManager.ReconfigExistingLoggers();
        }

        #region 菜单栏

        private void toolStripMenuItem_Open_Click(object sender, EventArgs e)
        {
            var dialog = new SkelSelectDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    spineManger.Add(Spine.Spine.New(dialog.Version, dialog.SkelPath, dialog.AtlasPath));
                }
                catch (Exception ex)
                {
                    Program.Logger.Error(ex.ToString());
                    Program.Logger.Error($"Failed to load {dialog.SkelPath} {dialog.AtlasPath}");
                    MessageBox.Show(ex.ToString(), "骨骼加载失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripMenuItem_BatchOpen_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem_Export_Click(object sender, EventArgs e)
        {
            var a = new SizeF(10, 100);
            spineManger.Spines[0].Position = spineManger.Spines[0].Position + a;
        }

        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region 模型列表

        // button_Add_Click => toolStripMenuItem_Open_Click

        private void button_Insert_Click(object sender, EventArgs e)
        {
            if (listView_SkelList.SelectedIndices.Count <= 0)
                return;

            var index = listView_SkelList.SelectedIndices[0];
            var dialog = new SkelSelectDialog();
            dialog.ShowDialog();
            try
            {
                spineManger.Insert(index, Spine.Spine.New(dialog.Version, dialog.SkelPath, dialog.AtlasPath));
            }
            catch (Exception ex)
            {
                Program.Logger.Error(ex.ToString());
                Program.Logger.Error($"Failed to load {dialog.SkelPath} {dialog.AtlasPath}");
            }
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            if (listView_SkelList.SelectedIndices.Count <= 0)
                return;
            spineManger.Remove(listView_SkelList.SelectedIndices.Cast<int>());
        }

        private void button_MoveUp_Click(object sender, EventArgs e)
        {
            if (listView_SkelList.SelectedIndices.Count <= 0)
                return;
            spineManger.MoveUp(listView_SkelList.SelectedIndices[0]);
        }

        private void button_MoveDown_Click(object sender, EventArgs e)
        {
            if (listView_SkelList.SelectedIndices.Count <= 0)
                return;
            spineManger.MoveDown(listView_SkelList.SelectedIndices[0]);
        }

        private void listView_SkelList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView_SkelList.SelectedIndices.Count <= 0)
            {
                button_Insert.Enabled = false;
                button_Remove.Enabled = false;
                button_MoveUp.Enabled = false;
                button_MoveDown.Enabled = false;
                propertyGrid_Skel.SelectedObject = null;
            }
            else if (listView_SkelList.SelectedIndices.Count <= 1)
            {
                button_Insert.Enabled = true;
                button_Remove.Enabled = true;
                button_MoveUp.Enabled = true;
                button_MoveDown.Enabled = true;
                propertyGrid_Skel.SelectedObject = spineManger.Spines[listView_SkelList.SelectedIndices[0]];
            }
            else
            {
                button_Insert.Enabled = false;
                button_Remove.Enabled = true;
                button_MoveUp.Enabled = false;
                button_MoveDown.Enabled = false;
                propertyGrid_Skel.SelectedObject = null;
            }
        }

        #endregion

        #region 画面参数
        #endregion

        #region 预览画面
        #endregion

        #region 杂项

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ActiveControl = null;
        }

        private void splitContainer_MouseUp(object sender, MouseEventArgs e)
        {
            ActiveControl = null;
        }
        
        #endregion
    }
}
