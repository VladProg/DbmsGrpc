using System.Drawing;
using System.Windows.Forms;

namespace DbmsWcfClient
{
    partial class FormCreateTable
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
            System.Windows.Forms.Label labelTableName;
            System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTableName;
            System.Windows.Forms.Button buttonAddColumn;
            this.textBoxTableName = new System.Windows.Forms.TextBox();
            this.buttonSaveTable = new System.Windows.Forms.Button();
            this.flowLayoutPanelButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanelAll = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBoxColumns = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanelColumns = new System.Windows.Forms.FlowLayoutPanel();
            labelTableName = new System.Windows.Forms.Label();
            flowLayoutPanelTableName = new System.Windows.Forms.FlowLayoutPanel();
            buttonAddColumn = new System.Windows.Forms.Button();
            flowLayoutPanelTableName.SuspendLayout();
            this.flowLayoutPanelButtons.SuspendLayout();
            this.flowLayoutPanelAll.SuspendLayout();
            this.groupBoxColumns.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTableName
            // 
            labelTableName.AutoSize = true;
            labelTableName.Location = new System.Drawing.Point(3, 0);
            labelTableName.MinimumSize = new System.Drawing.Size(0, 22);
            labelTableName.Name = "labelTableName";
            labelTableName.Size = new System.Drawing.Size(83, 22);
            labelTableName.TabIndex = 0;
            labelTableName.Text = "Table name:";
            labelTableName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // flowLayoutPanelTableName
            // 
            flowLayoutPanelTableName.AutoSize = true;
            flowLayoutPanelTableName.Controls.Add(labelTableName);
            flowLayoutPanelTableName.Controls.Add(this.textBoxTableName);
            flowLayoutPanelTableName.Location = new System.Drawing.Point(3, 2);
            flowLayoutPanelTableName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            flowLayoutPanelTableName.Name = "flowLayoutPanelTableName";
            flowLayoutPanelTableName.Size = new System.Drawing.Size(155, 26);
            flowLayoutPanelTableName.TabIndex = 2;
            // 
            // textBoxTableName
            // 
            this.textBoxTableName.Location = new System.Drawing.Point(92, 2);
            this.textBoxTableName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxTableName.Name = "textBoxTableName";
            this.textBoxTableName.Size = new System.Drawing.Size(60, 22);
            this.textBoxTableName.TabIndex = 1;
            this.textBoxTableName.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // buttonAddColumn
            // 
            buttonAddColumn.Location = new System.Drawing.Point(3, 2);
            buttonAddColumn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            buttonAddColumn.Name = "buttonAddColumn";
            buttonAddColumn.Size = new System.Drawing.Size(115, 23);
            buttonAddColumn.TabIndex = 3;
            buttonAddColumn.Text = "Add column";
            buttonAddColumn.UseVisualStyleBackColor = true;
            buttonAddColumn.Click += new System.EventHandler(this.buttonAddColumn_Click);
            // 
            // buttonSaveTable
            // 
            this.buttonSaveTable.Location = new System.Drawing.Point(124, 2);
            this.buttonSaveTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSaveTable.Name = "buttonSaveTable";
            this.buttonSaveTable.Size = new System.Drawing.Size(115, 23);
            this.buttonSaveTable.TabIndex = 4;
            this.buttonSaveTable.Text = "Save table";
            this.buttonSaveTable.UseVisualStyleBackColor = true;
            this.buttonSaveTable.Click += new System.EventHandler(this.buttonSaveTable_Click);
            // 
            // flowLayoutPanelButtons
            // 
            this.flowLayoutPanelButtons.AutoSize = true;
            this.flowLayoutPanelButtons.Controls.Add(buttonAddColumn);
            this.flowLayoutPanelButtons.Controls.Add(this.buttonSaveTable);
            this.flowLayoutPanelButtons.Location = new System.Drawing.Point(3, 55);
            this.flowLayoutPanelButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelButtons.Name = "flowLayoutPanelButtons";
            this.flowLayoutPanelButtons.Size = new System.Drawing.Size(242, 27);
            this.flowLayoutPanelButtons.TabIndex = 5;
            // 
            // flowLayoutPanelAll
            // 
            this.flowLayoutPanelAll.AutoScroll = true;
            this.flowLayoutPanelAll.Controls.Add(flowLayoutPanelTableName);
            this.flowLayoutPanelAll.Controls.Add(this.groupBoxColumns);
            this.flowLayoutPanelAll.Controls.Add(this.flowLayoutPanelButtons);
            this.flowLayoutPanelAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelAll.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelAll.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelAll.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelAll.Name = "flowLayoutPanelAll";
            this.flowLayoutPanelAll.Size = new System.Drawing.Size(800, 360);
            this.flowLayoutPanelAll.TabIndex = 0;
            this.flowLayoutPanelAll.WrapContents = false;
            // 
            // groupBoxColumns
            // 
            this.groupBoxColumns.AutoSize = true;
            this.groupBoxColumns.Controls.Add(this.flowLayoutPanelColumns);
            this.groupBoxColumns.Location = new System.Drawing.Point(3, 32);
            this.groupBoxColumns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxColumns.MinimumSize = new System.Drawing.Size(100, 16);
            this.groupBoxColumns.Name = "groupBoxColumns";
            this.groupBoxColumns.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxColumns.Size = new System.Drawing.Size(100, 19);
            this.groupBoxColumns.TabIndex = 6;
            this.groupBoxColumns.TabStop = false;
            this.groupBoxColumns.Text = "Columns";
            // 
            // flowLayoutPanelColumns
            // 
            this.flowLayoutPanelColumns.AutoSize = true;
            this.flowLayoutPanelColumns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelColumns.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelColumns.Location = new System.Drawing.Point(3, 17);
            this.flowLayoutPanelColumns.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanelColumns.Name = "flowLayoutPanelColumns";
            this.flowLayoutPanelColumns.Size = new System.Drawing.Size(94, 0);
            this.flowLayoutPanelColumns.TabIndex = 0;
            this.flowLayoutPanelColumns.WrapContents = false;
            // 
            // FormCreateTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 360);
            this.Controls.Add(this.flowLayoutPanelAll);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormCreateTable";
            this.Text = "Create new table";
            flowLayoutPanelTableName.ResumeLayout(false);
            flowLayoutPanelTableName.PerformLayout();
            this.flowLayoutPanelButtons.ResumeLayout(false);
            this.flowLayoutPanelAll.ResumeLayout(false);
            this.flowLayoutPanelAll.PerformLayout();
            this.groupBoxColumns.ResumeLayout(false);
            this.groupBoxColumns.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FlowLayoutPanel flowLayoutPanelAll;
        private FlowLayoutPanel flowLayoutPanelButtons;
        private Button buttonSaveTable;
        public TextBox textBoxTableName;
        private GroupBox groupBoxColumns;
        public FlowLayoutPanel flowLayoutPanelColumns;
    }
}