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
            tableLayoutPanel = new TableLayoutPanel();
            flowLayoutPanel_Buttons = new FlowLayoutPanel();
            button_Add = new Button();
            button_Insert = new Button();
            button_Remove = new Button();
            button_MoveUp = new Button();
            button_MoveDown = new Button();
            listView = new ListView();
            columnHeader_Name = new ColumnHeader();
            columnHeader_Version = new ColumnHeader();
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
            flowLayoutPanel_Buttons.Controls.Add(button_Insert);
            flowLayoutPanel_Buttons.Controls.Add(button_Remove);
            flowLayoutPanel_Buttons.Controls.Add(button_MoveUp);
            flowLayoutPanel_Buttons.Controls.Add(button_MoveDown);
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
            button_Add.Location = new Point(3, 3);
            button_Add.Name = "button_Add";
            button_Add.Size = new Size(56, 34);
            button_Add.TabIndex = 0;
            button_Add.Text = "添加";
            button_Add.UseVisualStyleBackColor = true;
            button_Add.Click += button_Add_Click;
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
            // listView
            // 
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
            listView.SelectedIndexChanged += listView_SelectedIndexChanged;
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
            // ListViewSkel
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Name = "ListViewSkel";
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
    }
}
