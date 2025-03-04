namespace SpineViewer.Dialogs
{
    partial class DiagnosticsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiagnosticsDialog));
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            button_Copy = new Button();
            propertyGrid = new PropertyGrid();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(50, 15, 50, 10);
            panel1.Size = new Size(901, 452);
            panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(button_Copy, 0, 1);
            tableLayoutPanel1.Controls.Add(propertyGrid, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(50, 15);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(801, 427);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // button_Copy
            // 
            button_Copy.Anchor = AnchorStyles.None;
            button_Copy.AutoSize = true;
            button_Copy.Location = new Point(326, 390);
            button_Copy.Margin = new Padding(3, 10, 3, 3);
            button_Copy.Name = "button_Copy";
            button_Copy.Padding = new Padding(10, 0, 10, 0);
            button_Copy.Size = new Size(148, 34);
            button_Copy.TabIndex = 12;
            button_Copy.Text = "复制到剪贴板";
            button_Copy.UseVisualStyleBackColor = true;
            button_Copy.Click += button_Copy_Click;
            // 
            // propertyGrid
            // 
            propertyGrid.Dock = DockStyle.Fill;
            propertyGrid.HelpVisible = false;
            propertyGrid.Location = new Point(3, 3);
            propertyGrid.Name = "propertyGrid";
            propertyGrid.Size = new Size(795, 374);
            propertyGrid.TabIndex = 13;
            propertyGrid.ToolbarVisible = false;
            // 
            // DiagnosticsDialog
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(901, 452);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DiagnosticsDialog";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "诊断信息";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button_Copy;
        private PropertyGrid propertyGrid;
    }
}