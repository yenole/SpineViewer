namespace SpineViewer
{
    partial class SpinePreviewer
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            panel = new Panel();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            SuspendLayout();
            // 
            // panel
            // 
            panel.BackColor = SystemColors.ControlDark;
            panel.Location = new Point(115, 75);
            panel.Margin = new Padding(0);
            panel.Name = "panel";
            panel.Size = new Size(513, 446);
            panel.TabIndex = 1;
            panel.MouseDown += panel_MouseDown;
            panel.MouseMove += panel_MouseMove;
            panel.MouseUp += panel_MouseUp;
            // 
            // backgroundWorker
            // 
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            // 
            // SpinePreviewer
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel);
            Name = "SpinePreviewer";
            Size = new Size(637, 534);
            SizeChanged += SpinePreviewer_SizeChanged;
            ResumeLayout(false);
        }

        #endregion

        private Panel panel;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}
