namespace SpineViewer.Dialogs
{
    partial class AboutDialog
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel_About = new TableLayoutPanel();
            label3 = new Label();
            label1 = new Label();
            label_Version = new Label();
            linkLabel_RepoUrl = new LinkLabel();
            panel1 = new Panel();
            tableLayoutPanel_About.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel_About
            // 
            tableLayoutPanel_About.BackColor = Color.Transparent;
            tableLayoutPanel_About.ColumnCount = 2;
            tableLayoutPanel_About.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.5714283F));
            tableLayoutPanel_About.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 71.42857F));
            tableLayoutPanel_About.Controls.Add(label3, 0, 1);
            tableLayoutPanel_About.Controls.Add(label1, 0, 0);
            tableLayoutPanel_About.Controls.Add(label_Version, 1, 0);
            tableLayoutPanel_About.Controls.Add(linkLabel_RepoUrl, 1, 1);
            tableLayoutPanel_About.Dock = DockStyle.Fill;
            tableLayoutPanel_About.Location = new Point(50, 15);
            tableLayoutPanel_About.Margin = new Padding(0);
            tableLayoutPanel_About.Name = "tableLayoutPanel_About";
            tableLayoutPanel_About.RowCount = 3;
            tableLayoutPanel_About.RowStyles.Add(new RowStyle());
            tableLayoutPanel_About.RowStyles.Add(new RowStyle());
            tableLayoutPanel_About.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel_About.Size = new Size(604, 254);
            tableLayoutPanel_About.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Dock = DockStyle.Fill;
            label3.Location = new Point(3, 54);
            label3.Margin = new Padding(3, 10, 3, 10);
            label3.Name = "label3";
            label3.Size = new Size(166, 24);
            label3.TabIndex = 2;
            label3.Text = "项目地址：";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 10);
            label1.Margin = new Padding(3, 10, 3, 10);
            label1.Name = "label1";
            label1.Size = new Size(166, 24);
            label1.TabIndex = 0;
            label1.Text = "程序版本：";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label_Version
            // 
            label_Version.Anchor = AnchorStyles.Left;
            label_Version.AutoSize = true;
            label_Version.Location = new Point(175, 10);
            label_Version.Name = "label_Version";
            label_Version.Size = new Size(61, 24);
            label_Version.TabIndex = 1;
            label_Version.Text = "vX.Y.Z";
            label_Version.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // linkLabel_RepoUrl
            // 
            linkLabel_RepoUrl.Anchor = AnchorStyles.Left;
            linkLabel_RepoUrl.AutoSize = true;
            linkLabel_RepoUrl.Location = new Point(175, 54);
            linkLabel_RepoUrl.Name = "linkLabel_RepoUrl";
            linkLabel_RepoUrl.Size = new Size(356, 24);
            linkLabel_RepoUrl.TabIndex = 3;
            linkLabel_RepoUrl.TabStop = true;
            linkLabel_RepoUrl.Text = "https://github.com/ww-rm/SpineViewer";
            linkLabel_RepoUrl.LinkClicked += linkLabel_RepoUrl_LinkClicked;
            // 
            // panel1
            // 
            panel1.BackgroundImageLayout = ImageLayout.Center;
            panel1.Controls.Add(tableLayoutPanel_About);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(16, 17);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(50, 15, 50, 10);
            panel1.Size = new Size(704, 279);
            panel1.TabIndex = 2;
            // 
            // AboutDialog
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(736, 313);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(6);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutDialog";
            Padding = new Padding(16, 17, 16, 17);
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "关于";
            tableLayoutPanel_About.ResumeLayout(false);
            tableLayoutPanel_About.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel_About;
        private Label label3;
        private Label label1;
        private Label label_Version;
        private LinkLabel linkLabel_RepoUrl;
        private Panel panel1;
    }
}
