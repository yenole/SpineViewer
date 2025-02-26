namespace SpineViewer
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "A Loooooooooog Name1", "A Loooooooooog Version" }, -1);
            menuStrip = new MenuStrip();
            toolStripMenuItem_File = new ToolStripMenuItem();
            toolStripMenuItem_Open = new ToolStripMenuItem();
            toolStripMenuItem_BatchOpen = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripMenuItem_Export = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripMenuItem_Exit = new ToolStripMenuItem();
            toolStripMenuItem_Help = new ToolStripMenuItem();
            toolStripMenuItem_About = new ToolStripMenuItem();
            rtbLog = new RichTextBox();
            splitContainer_MainForm = new SplitContainer();
            splitContainer_Functional = new SplitContainer();
            splitContainer_Information = new SplitContainer();
            groupBox_SkelList = new GroupBox();
            tableLayoutPanel = new TableLayoutPanel();
            flowLayoutPanel_Buttons = new FlowLayoutPanel();
            button_Add = new Button();
            button_Insert = new Button();
            button_Remove = new Button();
            button_MoveUp = new Button();
            button_MoveDown = new Button();
            listView_SkelList = new ListView();
            columnHeader_Name = new ColumnHeader();
            columnHeader_Version = new ColumnHeader();
            splitContainer_Config = new SplitContainer();
            groupBox_SkelConfig = new GroupBox();
            propertyGrid_Skel = new PropertyGrid();
            groupBox_PreviewConfig = new GroupBox();
            groupBox_Preview = new GroupBox();
            panel_PreviewContainer = new Panel();
            panel_Preview = new Panel();
            panel_MainForm = new Panel();
            openFileDialog_Skel = new OpenFileDialog();
            openFileDialog_Atlas = new OpenFileDialog();
            toolTip1 = new ToolTip(components);
            menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_MainForm).BeginInit();
            splitContainer_MainForm.Panel1.SuspendLayout();
            splitContainer_MainForm.Panel2.SuspendLayout();
            splitContainer_MainForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Functional).BeginInit();
            splitContainer_Functional.Panel1.SuspendLayout();
            splitContainer_Functional.Panel2.SuspendLayout();
            splitContainer_Functional.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Information).BeginInit();
            splitContainer_Information.Panel1.SuspendLayout();
            splitContainer_Information.Panel2.SuspendLayout();
            splitContainer_Information.SuspendLayout();
            groupBox_SkelList.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            flowLayoutPanel_Buttons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer_Config).BeginInit();
            splitContainer_Config.Panel1.SuspendLayout();
            splitContainer_Config.Panel2.SuspendLayout();
            splitContainer_Config.SuspendLayout();
            groupBox_SkelConfig.SuspendLayout();
            groupBox_Preview.SuspendLayout();
            panel_PreviewContainer.SuspendLayout();
            panel_MainForm.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.BackColor = SystemColors.Control;
            menuStrip.ImageScalingSize = new Size(24, 24);
            menuStrip.Items.AddRange(new ToolStripItem[] { toolStripMenuItem_File, toolStripMenuItem_Help });
            menuStrip.Location = new Point(0, 0);
            menuStrip.Name = "menuStrip";
            menuStrip.Size = new Size(1519, 32);
            menuStrip.TabIndex = 0;
            menuStrip.Text = "菜单";
            // 
            // toolStripMenuItem_File
            // 
            toolStripMenuItem_File.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_Open, toolStripMenuItem_BatchOpen, toolStripSeparator1, toolStripMenuItem_Export, toolStripSeparator2, toolStripMenuItem_Exit });
            toolStripMenuItem_File.Name = "toolStripMenuItem_File";
            toolStripMenuItem_File.Size = new Size(84, 28);
            toolStripMenuItem_File.Text = "文件(&F)";
            // 
            // toolStripMenuItem_Open
            // 
            toolStripMenuItem_Open.Name = "toolStripMenuItem_Open";
            toolStripMenuItem_Open.ShortcutKeys = Keys.Control | Keys.O;
            toolStripMenuItem_Open.Size = new Size(254, 34);
            toolStripMenuItem_Open.Text = "打开(&O)...";
            toolStripMenuItem_Open.Click += toolStripMenuItem_Open_Click;
            // 
            // toolStripMenuItem_BatchOpen
            // 
            toolStripMenuItem_BatchOpen.Name = "toolStripMenuItem_BatchOpen";
            toolStripMenuItem_BatchOpen.Size = new Size(254, 34);
            toolStripMenuItem_BatchOpen.Text = "批量打开(&B)...";
            toolStripMenuItem_BatchOpen.Click += toolStripMenuItem_BatchOpen_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(251, 6);
            // 
            // toolStripMenuItem_Export
            // 
            toolStripMenuItem_Export.Name = "toolStripMenuItem_Export";
            toolStripMenuItem_Export.ShortcutKeys = Keys.Control | Keys.S;
            toolStripMenuItem_Export.Size = new Size(254, 34);
            toolStripMenuItem_Export.Text = "导出(&E)...";
            toolStripMenuItem_Export.Click += toolStripMenuItem_Export_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(251, 6);
            // 
            // toolStripMenuItem_Exit
            // 
            toolStripMenuItem_Exit.Name = "toolStripMenuItem_Exit";
            toolStripMenuItem_Exit.ShortcutKeys = Keys.Alt | Keys.F4;
            toolStripMenuItem_Exit.Size = new Size(254, 34);
            toolStripMenuItem_Exit.Text = "退出(&X)";
            toolStripMenuItem_Exit.Click += toolStripMenuItem_Exit_Click;
            // 
            // toolStripMenuItem_Help
            // 
            toolStripMenuItem_Help.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_About });
            toolStripMenuItem_Help.Name = "toolStripMenuItem_Help";
            toolStripMenuItem_Help.Size = new Size(88, 28);
            toolStripMenuItem_Help.Text = "帮助(&H)";
            // 
            // toolStripMenuItem_About
            // 
            toolStripMenuItem_About.Name = "toolStripMenuItem_About";
            toolStripMenuItem_About.Size = new Size(171, 34);
            toolStripMenuItem_About.Text = "关于(&A)";
            // 
            // rtbLog
            // 
            rtbLog.BackColor = SystemColors.Window;
            rtbLog.BorderStyle = BorderStyle.None;
            rtbLog.Dock = DockStyle.Fill;
            rtbLog.Font = new Font("Consolas", 9F);
            rtbLog.Location = new Point(0, 0);
            rtbLog.Margin = new Padding(3, 2, 3, 2);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(1499, 102);
            rtbLog.TabIndex = 0;
            rtbLog.Text = "";
            rtbLog.WordWrap = false;
            // 
            // splitContainer_MainForm
            // 
            splitContainer_MainForm.Cursor = Cursors.SizeNS;
            splitContainer_MainForm.Dock = DockStyle.Fill;
            splitContainer_MainForm.Location = new Point(10, 5);
            splitContainer_MainForm.Name = "splitContainer_MainForm";
            splitContainer_MainForm.Orientation = Orientation.Horizontal;
            // 
            // splitContainer_MainForm.Panel1
            // 
            splitContainer_MainForm.Panel1.Controls.Add(splitContainer_Functional);
            splitContainer_MainForm.Panel1.Cursor = Cursors.Default;
            // 
            // splitContainer_MainForm.Panel2
            // 
            splitContainer_MainForm.Panel2.Controls.Add(rtbLog);
            splitContainer_MainForm.Panel2.Cursor = Cursors.Default;
            splitContainer_MainForm.Size = new Size(1499, 838);
            splitContainer_MainForm.SplitterDistance = 732;
            splitContainer_MainForm.TabIndex = 3;
            splitContainer_MainForm.TabStop = false;
            splitContainer_MainForm.SplitterMoved += splitContainer_SplitterMoved;
            splitContainer_MainForm.MouseUp += splitContainer_MouseUp;
            // 
            // splitContainer_Functional
            // 
            splitContainer_Functional.Cursor = Cursors.SizeWE;
            splitContainer_Functional.Dock = DockStyle.Fill;
            splitContainer_Functional.Location = new Point(0, 0);
            splitContainer_Functional.Name = "splitContainer_Functional";
            // 
            // splitContainer_Functional.Panel1
            // 
            splitContainer_Functional.Panel1.Controls.Add(splitContainer_Information);
            splitContainer_Functional.Panel1.Cursor = Cursors.Default;
            // 
            // splitContainer_Functional.Panel2
            // 
            splitContainer_Functional.Panel2.Controls.Add(groupBox_Preview);
            splitContainer_Functional.Panel2.Cursor = Cursors.Default;
            splitContainer_Functional.Size = new Size(1499, 732);
            splitContainer_Functional.SplitterDistance = 698;
            splitContainer_Functional.TabIndex = 2;
            splitContainer_Functional.TabStop = false;
            splitContainer_Functional.SplitterMoved += splitContainer_SplitterMoved;
            splitContainer_Functional.MouseUp += splitContainer_MouseUp;
            // 
            // splitContainer_Information
            // 
            splitContainer_Information.Cursor = Cursors.SizeWE;
            splitContainer_Information.Dock = DockStyle.Fill;
            splitContainer_Information.Location = new Point(0, 0);
            splitContainer_Information.Name = "splitContainer_Information";
            // 
            // splitContainer_Information.Panel1
            // 
            splitContainer_Information.Panel1.Controls.Add(groupBox_SkelList);
            splitContainer_Information.Panel1.Cursor = Cursors.Default;
            // 
            // splitContainer_Information.Panel2
            // 
            splitContainer_Information.Panel2.Controls.Add(splitContainer_Config);
            splitContainer_Information.Panel2.Cursor = Cursors.Default;
            splitContainer_Information.Size = new Size(698, 732);
            splitContainer_Information.SplitterDistance = 336;
            splitContainer_Information.TabIndex = 1;
            splitContainer_Information.TabStop = false;
            splitContainer_Information.SplitterMoved += splitContainer_SplitterMoved;
            splitContainer_Information.MouseUp += splitContainer_MouseUp;
            // 
            // groupBox_SkelList
            // 
            groupBox_SkelList.Controls.Add(tableLayoutPanel);
            groupBox_SkelList.Dock = DockStyle.Fill;
            groupBox_SkelList.Location = new Point(0, 0);
            groupBox_SkelList.Name = "groupBox_SkelList";
            groupBox_SkelList.Size = new Size(336, 732);
            groupBox_SkelList.TabIndex = 0;
            groupBox_SkelList.TabStop = false;
            groupBox_SkelList.Text = "模型列表";
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(flowLayoutPanel_Buttons, 0, 0);
            tableLayoutPanel.Controls.Add(listView_SkelList, 0, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(3, 26);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(330, 703);
            tableLayoutPanel.TabIndex = 1;
            // 
            // flowLayoutPanel_Buttons
            // 
            flowLayoutPanel_Buttons.AutoSize = true;
            flowLayoutPanel_Buttons.Controls.Add(button_Add);
            flowLayoutPanel_Buttons.Controls.Add(button_Insert);
            flowLayoutPanel_Buttons.Controls.Add(button_Remove);
            flowLayoutPanel_Buttons.Controls.Add(button_MoveUp);
            flowLayoutPanel_Buttons.Controls.Add(button_MoveDown);
            flowLayoutPanel_Buttons.Dock = DockStyle.Fill;
            flowLayoutPanel_Buttons.Location = new Point(3, 3);
            flowLayoutPanel_Buttons.Name = "flowLayoutPanel_Buttons";
            flowLayoutPanel_Buttons.Size = new Size(324, 40);
            flowLayoutPanel_Buttons.TabIndex = 4;
            // 
            // button_Add
            // 
            button_Add.Anchor = AnchorStyles.None;
            button_Add.AutoSize = true;
            button_Add.Location = new Point(3, 3);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(56, 34);
            button_Add.TabIndex = 0;
            button_Add.Text = "添加";
            button_Add.UseVisualStyleBackColor = true;
            button_Add.Click += toolStripMenuItem_Open_Click;
            // 
            // button_Insert
            // 
            button_Insert.Anchor = AnchorStyles.None;
            button_Insert.AutoSize = true;
            button_Insert.Enabled = false;
            button_Insert.Location = new Point(65, 3);
            button_Insert.Name = "button_Insert";
            button_Insert.Size = new Size(56, 34);
            button_Insert.TabIndex = 4;
            button_Insert.Text = "插入";
            button_Insert.UseVisualStyleBackColor = true;
            button_Insert.Click += button_Insert_Click;
            // 
            // button_Remove
            // 
            button_Remove.Anchor = AnchorStyles.None;
            button_Remove.AutoSize = true;
            button_Remove.Enabled = false;
            button_Remove.Location = new Point(127, 3);
            button_Remove.Name = "button_Remove";
            button_Remove.Size = new Size(56, 34);
            button_Remove.TabIndex = 1;
            button_Remove.Text = "移除";
            button_Remove.UseVisualStyleBackColor = true;
            button_Remove.Click += button_Remove_Click;
            // 
            // button_MoveUp
            // 
            button_MoveUp.Anchor = AnchorStyles.None;
            button_MoveUp.AutoSize = true;
            button_MoveUp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_MoveUp.Enabled = false;
            button_MoveUp.Location = new Point(189, 3);
            button_MoveUp.Name = "button_MoveUp";
            button_MoveUp.Size = new Size(56, 34);
            button_MoveUp.TabIndex = 2;
            button_MoveUp.Text = "上移";
            button_MoveUp.UseVisualStyleBackColor = true;
            button_MoveUp.Click += button_MoveUp_Click;
            // 
            // button_MoveDown
            // 
            button_MoveDown.Anchor = AnchorStyles.None;
            button_MoveDown.AutoSize = true;
            button_MoveDown.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_MoveDown.Enabled = false;
            button_MoveDown.Location = new Point(251, 3);
            button_MoveDown.Name = "button_MoveDown";
            button_MoveDown.Size = new Size(56, 34);
            button_MoveDown.TabIndex = 3;
            button_MoveDown.Text = "下移";
            button_MoveDown.UseVisualStyleBackColor = true;
            button_MoveDown.Click += button_MoveDown_Click;
            // 
            // listView_SkelList
            // 
            listView_SkelList.Columns.AddRange(new ColumnHeader[] { columnHeader_Name, columnHeader_Version });
            listView_SkelList.Dock = DockStyle.Fill;
            listView_SkelList.FullRowSelect = true;
            listView_SkelList.GridLines = true;
            listView_SkelList.Items.AddRange(new ListViewItem[] { listViewItem1 });
            listView_SkelList.Location = new Point(3, 49);
            listView_SkelList.Name = "listView_SkelList";
            listView_SkelList.ShowItemToolTips = true;
            listView_SkelList.Size = new Size(324, 651);
            listView_SkelList.TabIndex = 1;
            listView_SkelList.UseCompatibleStateImageBehavior = false;
            listView_SkelList.View = View.Details;
            listView_SkelList.SelectedIndexChanged += listView_SkelList_SelectedIndexChanged;
            // 
            // columnHeader_Name
            // 
            columnHeader_Name.Text = "名称";
            columnHeader_Name.Width = 150;
            // 
            // columnHeader_Version
            // 
            columnHeader_Version.Text = "版本";
            columnHeader_Version.Width = 150;
            // 
            // splitContainer_Config
            // 
            splitContainer_Config.Cursor = Cursors.SizeNS;
            splitContainer_Config.Dock = DockStyle.Fill;
            splitContainer_Config.Location = new Point(0, 0);
            splitContainer_Config.Name = "splitContainer_Config";
            splitContainer_Config.Orientation = Orientation.Horizontal;
            // 
            // splitContainer_Config.Panel1
            // 
            splitContainer_Config.Panel1.Controls.Add(groupBox_SkelConfig);
            splitContainer_Config.Panel1.Cursor = Cursors.Default;
            // 
            // splitContainer_Config.Panel2
            // 
            splitContainer_Config.Panel2.Controls.Add(groupBox_PreviewConfig);
            splitContainer_Config.Panel2.Cursor = Cursors.Default;
            splitContainer_Config.Size = new Size(358, 732);
            splitContainer_Config.SplitterDistance = 493;
            splitContainer_Config.TabIndex = 0;
            splitContainer_Config.TabStop = false;
            splitContainer_Config.SplitterMoved += splitContainer_SplitterMoved;
            splitContainer_Config.MouseUp += splitContainer_MouseUp;
            // 
            // groupBox_SkelConfig
            // 
            groupBox_SkelConfig.Controls.Add(propertyGrid_Skel);
            groupBox_SkelConfig.Dock = DockStyle.Fill;
            groupBox_SkelConfig.Location = new Point(0, 0);
            groupBox_SkelConfig.Name = "groupBox_SkelConfig";
            groupBox_SkelConfig.Size = new Size(358, 493);
            groupBox_SkelConfig.TabIndex = 0;
            groupBox_SkelConfig.TabStop = false;
            groupBox_SkelConfig.Text = "模型参数";
            // 
            // propertyGrid_Skel
            // 
            propertyGrid_Skel.Dock = DockStyle.Fill;
            propertyGrid_Skel.HelpVisible = false;
            propertyGrid_Skel.Location = new Point(3, 26);
            propertyGrid_Skel.Name = "propertyGrid_Skel";
            propertyGrid_Skel.Size = new Size(352, 464);
            propertyGrid_Skel.TabIndex = 0;
            propertyGrid_Skel.ToolbarVisible = false;
            // 
            // groupBox_PreviewConfig
            // 
            groupBox_PreviewConfig.Dock = DockStyle.Fill;
            groupBox_PreviewConfig.Location = new Point(0, 0);
            groupBox_PreviewConfig.Name = "groupBox_PreviewConfig";
            groupBox_PreviewConfig.Size = new Size(358, 235);
            groupBox_PreviewConfig.TabIndex = 1;
            groupBox_PreviewConfig.TabStop = false;
            groupBox_PreviewConfig.Text = "画面参数";
            // 
            // groupBox_Preview
            // 
            groupBox_Preview.Controls.Add(panel_PreviewContainer);
            groupBox_Preview.Dock = DockStyle.Fill;
            groupBox_Preview.Location = new Point(0, 0);
            groupBox_Preview.Name = "groupBox_Preview";
            groupBox_Preview.Size = new Size(797, 732);
            groupBox_Preview.TabIndex = 1;
            groupBox_Preview.TabStop = false;
            groupBox_Preview.Text = "预览画面";
            // 
            // panel_PreviewContainer
            // 
            panel_PreviewContainer.Controls.Add(panel_Preview);
            panel_PreviewContainer.Dock = DockStyle.Fill;
            panel_PreviewContainer.Location = new Point(3, 26);
            panel_PreviewContainer.Margin = new Padding(0);
            panel_PreviewContainer.Name = "panel_PreviewContainer";
            panel_PreviewContainer.Size = new Size(791, 703);
            panel_PreviewContainer.TabIndex = 1;
            // 
            // panel_Preview
            // 
            panel_Preview.BackColor = SystemColors.ControlDark;
            panel_Preview.Location = new Point(107, 95);
            panel_Preview.Name = "panel_Preview";
            panel_Preview.Size = new Size(256, 256);
            panel_Preview.TabIndex = 0;
            // 
            // panel_MainForm
            // 
            panel_MainForm.Controls.Add(splitContainer_MainForm);
            panel_MainForm.Dock = DockStyle.Fill;
            panel_MainForm.Location = new Point(0, 32);
            panel_MainForm.Name = "panel_MainForm";
            panel_MainForm.Padding = new Padding(10, 5, 10, 10);
            panel_MainForm.Size = new Size(1519, 853);
            panel_MainForm.TabIndex = 4;
            // 
            // openFileDialog_Skel
            // 
            openFileDialog_Skel.AddExtension = false;
            openFileDialog_Skel.AddToRecent = false;
            openFileDialog_Skel.Filter = "skel 文件 (*.skel; *.json)|*.skel;*.json";
            // 
            // openFileDialog_Atlas
            // 
            openFileDialog_Atlas.AddExtension = false;
            openFileDialog_Atlas.AddToRecent = false;
            openFileDialog_Atlas.Filter = "atlas 文件 (*.atlas)|*.atlas";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1519, 885);
            Controls.Add(panel_MainForm);
            Controls.Add(menuStrip);
            MainMenuStrip = menuStrip;
            Margin = new Padding(3, 2, 3, 2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SpineViewer";
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            splitContainer_MainForm.Panel1.ResumeLayout(false);
            splitContainer_MainForm.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_MainForm).EndInit();
            splitContainer_MainForm.ResumeLayout(false);
            splitContainer_Functional.Panel1.ResumeLayout(false);
            splitContainer_Functional.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_Functional).EndInit();
            splitContainer_Functional.ResumeLayout(false);
            splitContainer_Information.Panel1.ResumeLayout(false);
            splitContainer_Information.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_Information).EndInit();
            splitContainer_Information.ResumeLayout(false);
            groupBox_SkelList.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            flowLayoutPanel_Buttons.ResumeLayout(false);
            flowLayoutPanel_Buttons.PerformLayout();
            splitContainer_Config.Panel1.ResumeLayout(false);
            splitContainer_Config.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer_Config).EndInit();
            splitContainer_Config.ResumeLayout(false);
            groupBox_SkelConfig.ResumeLayout(false);
            groupBox_Preview.ResumeLayout(false);
            panel_PreviewContainer.ResumeLayout(false);
            panel_MainForm.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem toolStripMenuItem_File;
        private ToolStripMenuItem toolStripMenuItem_Open;
        private ToolStripMenuItem toolStripMenuItem_Exit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem toolStripMenuItem_Export;
        private ToolStripSeparator toolStripSeparator2;
        private RichTextBox rtbLog;
        private SplitContainer splitContainer_MainForm;
        private SplitContainer splitContainer_Functional;
        private SplitContainer splitContainer_Information;
        private GroupBox groupBox_SkelList;
        private GroupBox groupBox_SkelConfig;
        private SplitContainer splitContainer_Config;
        private GroupBox groupBox_PreviewConfig;
        private Panel panel_MainForm;
        private ToolStripMenuItem toolStripMenuItem_Help;
        private ToolStripMenuItem toolStripMenuItem_About;
        private ToolStripMenuItem toolStripMenuItem_BatchOpen;
        private TableLayoutPanel tableLayoutPanel;
        private FlowLayoutPanel flowLayoutPanel_Buttons;
        private Button button_Add;
        private Button button_Insert;
        private Button button_Remove;
        private Button button_MoveUp;
        private Button button_MoveDown;
        private ListView listView_SkelList;
        private ColumnHeader columnHeader_Name;
        private ColumnHeader columnHeader_Version;
        private GroupBox groupBox_Preview;
        private Panel panel_Preview;
        private Panel panel_PreviewContainer;
        private OpenFileDialog openFileDialog_Skel;
        private OpenFileDialog openFileDialog_Atlas;
        private ToolTip toolTip1;
        private PropertyGrid propertyGrid_Skel;
    }
}
