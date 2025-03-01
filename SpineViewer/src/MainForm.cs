using NLog;
using SpineViewer.Spine;
using System.ComponentModel;
using System.Diagnostics;

namespace SpineViewer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            InitializeLogConfiguration();
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
            rtbTarget.WordColoringRules.Add(new("[I]", "DimGray", "Empty", FontStyle.Bold));
            rtbTarget.WordColoringRules.Add(new("[W]", "DarkOrange", "Empty", FontStyle.Bold));
            rtbTarget.WordColoringRules.Add(new("[E]", "Red", "Empty", FontStyle.Bold));
            rtbTarget.WordColoringRules.Add(new("[F]", "DarkRed", "Empty", FontStyle.Bold));

            LogManager.Configuration.AddTarget(rtbTarget);
            LogManager.Configuration.AddRule(LogLevel.Debug, LogLevel.Fatal, rtbTarget);
            LogManager.ReconfigExistingLoggers();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            spinePreviewer.StartPreview();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            spinePreviewer.StopPreview();
        }

        private void toolStripMenuItem_Open_Click(object sender, EventArgs e)
        {
            spineListView.Add();
        }

        private void toolStripMenuItem_BatchOpen_Click(object sender, EventArgs e)
        {
            spineListView.BatchAdd();
        }

        private void toolStripMenuItem_Export_Click(object sender, EventArgs e)
        {
            Program.Logger.Debug("Debug Test");
            Program.Logger.Info("Info Test");
            Program.Logger.Warn("Warn Test");
            Program.Logger.Error("Error Test");
            Program.Logger.Fatal("Fatal Test");
        }

        private void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void toolStripMenuItem_ResetAnimation_Click(object sender, EventArgs e)
        {
            spinePreviewer.StopPreview();
            foreach (var spine in spineListView.Spines)
                spine.CurrentAnimation = spine.CurrentAnimation;
            spinePreviewer.StartPreview();
        }

        private void splitContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            ActiveControl = null;
        }

        private void splitContainer_MouseUp(object sender, MouseEventArgs e)
        {
            ActiveControl = null;
        }

        private void propertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e)
        {
            (sender as PropertyGrid)?.Refresh();
        }

        private void spinePreviewer_MouseUp(object sender, MouseEventArgs e)
        {
            propertyGrid_Spine.Refresh();
        }
    }
}
