namespace SpineViewer
{
    partial class SpineListView
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpineListView));
            tableLayoutPanel = new TableLayoutPanel();
            flowLayoutPanel_Buttons = new FlowLayoutPanel();
            button_Add = new Button();
            button_Remove = new Button();
            button_MoveUp = new Button();
            button_MoveDown = new Button();
            button_Insert = new Button();
            button_RemoveAll = new Button();
            listView = new ListView();
            columnHeader_Name = new ColumnHeader();
            columnHeader_Version = new ColumnHeader();
            toolTip = new ToolTip(components);
            tableLayoutPanel.SuspendLayout();
            flowLayoutPanel_Buttons.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Controls.Add(flowLayoutPanel_Buttons, 0, 0);
            tableLayoutPanel.Controls.Add(listView, 0, 1);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Margin = new Padding(0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.Size = new Size(336, 445);
            tableLayoutPanel.TabIndex = 2;
            // 
            // flowLayoutPanel_Buttons
            // 
            flowLayoutPanel_Buttons.AutoSize = true;
            flowLayoutPanel_Buttons.Controls.Add(button_Add);
            flowLayoutPanel_Buttons.Controls.Add(button_Remove);
            flowLayoutPanel_Buttons.Controls.Add(button_MoveUp);
            flowLayoutPanel_Buttons.Controls.Add(button_MoveDown);
            flowLayoutPanel_Buttons.Controls.Add(button_Insert);
            flowLayoutPanel_Buttons.Controls.Add(button_RemoveAll);
            flowLayoutPanel_Buttons.Dock = DockStyle.Fill;
            flowLayoutPanel_Buttons.Location = new Point(3, 3);
            flowLayoutPanel_Buttons.Name = "flowLayoutPanel_Buttons";
            flowLayoutPanel_Buttons.Size = new Size(330, 40);
            flowLayoutPanel_Buttons.TabIndex = 4;
            // 
            // button_Add
            // 
            button_Add.Anchor = AnchorStyles.None;
            button_Add.AutoSize = true;
            button_Add.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_Add.Image = (Image)resources.GetObject("button_Add.Image");
            button_Add.Location = new Point(3, 3);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(34, 34);
            button_Add.TabIndex = 0;
            toolTip.SetToolTip(button_Add, "在末尾添加项");
            button_Add.UseVisualStyleBackColor = true;
            button_Add.Click += button_Add_Click;
            // 
            // button_Remove
            // 
            button_Remove.Anchor = AnchorStyles.None;
            button_Remove.AutoSize = true;
            button_Remove.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_Remove.Enabled = false;
            button_Remove.Image = (Image)resources.GetObject("button_Remove.Image");
            button_Remove.Location = new Point(43, 3);
            button_Remove.Name = "button_Remove";
            button_Remove.Size = new Size(34, 34);
            button_Remove.TabIndex = 1;
            toolTip.SetToolTip(button_Remove, "移除选中项");
            button_Remove.UseVisualStyleBackColor = true;
            button_Remove.Click += button_Remove_Click;
            // 
            // button_MoveUp
            // 
            button_MoveUp.Anchor = AnchorStyles.None;
            button_MoveUp.AutoSize = true;
            button_MoveUp.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_MoveUp.Enabled = false;
            button_MoveUp.Image = (Image)resources.GetObject("button_MoveUp.Image");
            button_MoveUp.Location = new Point(83, 3);
            button_MoveUp.Name = "button_MoveUp";
            button_MoveUp.Size = new Size(34, 34);
            button_MoveUp.TabIndex = 2;
            toolTip.SetToolTip(button_MoveUp, "上移选中项");
            button_MoveUp.UseVisualStyleBackColor = true;
            button_MoveUp.Click += button_MoveUp_Click;
            // 
            // button_MoveDown
            // 
            button_MoveDown.Anchor = AnchorStyles.None;
            button_MoveDown.AutoSize = true;
            button_MoveDown.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_MoveDown.Enabled = false;
            button_MoveDown.Image = (Image)resources.GetObject("button_MoveDown.Image");
            button_MoveDown.Location = new Point(123, 3);
            button_MoveDown.Name = "button_MoveDown";
            button_MoveDown.Size = new Size(34, 34);
            button_MoveDown.TabIndex = 3;
            toolTip.SetToolTip(button_MoveDown, "下移选中项");
            button_MoveDown.UseVisualStyleBackColor = true;
            button_MoveDown.Click += button_MoveDown_Click;
            // 
            // button_Insert
            // 
            button_Insert.Anchor = AnchorStyles.None;
            button_Insert.AutoSize = true;
            button_Insert.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_Insert.Enabled = false;
            button_Insert.Image = (Image)resources.GetObject("button_Insert.Image");
            button_Insert.Location = new Point(163, 3);
            button_Insert.Name = "button_Insert";
            button_Insert.Size = new Size(34, 34);
            button_Insert.TabIndex = 4;
            toolTip.SetToolTip(button_Insert, "在选中项之前插入项");
            button_Insert.UseVisualStyleBackColor = true;
            button_Insert.Click += button_Insert_Click;
            // 
            // button_RemoveAll
            // 
            button_RemoveAll.Anchor = AnchorStyles.None;
            button_RemoveAll.AutoSize = true;
            button_RemoveAll.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button_RemoveAll.Image = (Image)resources.GetObject("button_RemoveAll.Image");
            button_RemoveAll.Location = new Point(203, 3);
            button_RemoveAll.Name = "button_RemoveAll";
            button_RemoveAll.Size = new Size(34, 34);
            button_RemoveAll.TabIndex = 5;
            toolTip.SetToolTip(button_RemoveAll, "移除所有项");
            button_RemoveAll.UseVisualStyleBackColor = true;
            button_RemoveAll.Click += button_RemoveAll_Click;
            // 
            // listView
            // 
            listView.AllowDrop = true;
            listView.Columns.AddRange(new ColumnHeader[] { columnHeader_Name, columnHeader_Version });
            listView.Dock = DockStyle.Fill;
            listView.FullRowSelect = true;
            listView.GridLines = true;
            listView.Location = new Point(3, 49);
            listView.Name = "listView";
            listView.ShowItemToolTips = true;
            listView.Size = new Size(330, 393);
            listView.TabIndex = 1;
            listView.UseCompatibleStateImageBehavior = false;
            listView.View = View.Details;
            listView.ItemDrag += listView_ItemDrag;
            listView.SelectedIndexChanged += listView_SelectedIndexChanged;
            listView.DragDrop += listView_DragDrop;
            listView.DragOver += listView_DragOver;
            listView.KeyDown += listView_KeyDown;
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
            // SpineListView
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "SpineListView";
            Size = new Size(336, 445);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            flowLayoutPanel_Buttons.ResumeLayout(false);
            flowLayoutPanel_Buttons.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel;
        private FlowLayoutPanel flowLayoutPanel_Buttons;
        private Button button_Insert;
        private Button button_Remove;
        private Button button_MoveUp;
        private Button button_MoveDown;
        private ListView listView;
        private ColumnHeader columnHeader_Name;
        private ColumnHeader columnHeader_Version;
        private Button button_Add;
        private Button button_RemoveAll;
        private ToolTip toolTip;
    }
}
