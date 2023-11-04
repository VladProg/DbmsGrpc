using System;
using System.Drawing;
using System.Windows.Forms;

namespace DbmsWcfClient
{
    partial class FormDatabase
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
            System.Windows.Forms.Button buttonCreateTable;
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxDifferences = new System.Windows.Forms.GroupBox();
            this.groupBoxTables = new System.Windows.Forms.GroupBox();
            buttonCreateTable = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreateTable
            // 
            buttonCreateTable.AutoEllipsis = true;
            buttonCreateTable.Dock = System.Windows.Forms.DockStyle.Top;
            buttonCreateTable.Location = new System.Drawing.Point(0, 0);
            buttonCreateTable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            buttonCreateTable.Name = "buttonCreateTable";
            buttonCreateTable.Size = new System.Drawing.Size(266, 23);
            buttonCreateTable.TabIndex = 1;
            buttonCreateTable.Text = "Create new table";
            buttonCreateTable.UseVisualStyleBackColor = true;
            buttonCreateTable.Click += new System.EventHandler(this.buttonCreateTable_Click);
            // 
            // splitContainer
            // 
            this.splitContainer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel1.Controls.Add(this.panel1);
            this.splitContainer.Panel1.Controls.Add(buttonCreateTable);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer.Panel2.SizeChanged += new System.EventHandler(this.splitContainer_Panel2_SizeChanged);
            this.splitContainer.Size = new System.Drawing.Size(1161, 470);
            this.splitContainer.SplitterDistance = 266;
            this.splitContainer.SplitterWidth = 5;
            this.splitContainer.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.groupBoxDifferences);
            this.panel1.Controls.Add(this.groupBoxTables);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(266, 447);
            this.panel1.TabIndex = 5;
            // 
            // groupBoxDifferences
            // 
            this.groupBoxDifferences.AutoSize = true;
            this.groupBoxDifferences.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxDifferences.Location = new System.Drawing.Point(0, 24);
            this.groupBoxDifferences.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDifferences.MinimumSize = new System.Drawing.Size(0, 24);
            this.groupBoxDifferences.Name = "groupBoxDifferences";
            this.groupBoxDifferences.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxDifferences.Size = new System.Drawing.Size(266, 24);
            this.groupBoxDifferences.TabIndex = 4;
            this.groupBoxDifferences.TabStop = false;
            this.groupBoxDifferences.Text = "Table differences";
            // 
            // groupBoxTables
            // 
            this.groupBoxTables.AutoSize = true;
            this.groupBoxTables.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxTables.Location = new System.Drawing.Point(0, 0);
            this.groupBoxTables.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxTables.MinimumSize = new System.Drawing.Size(0, 24);
            this.groupBoxTables.Name = "groupBoxTables";
            this.groupBoxTables.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBoxTables.Size = new System.Drawing.Size(266, 24);
            this.groupBoxTables.TabIndex = 3;
            this.groupBoxTables.TabStop = false;
            this.groupBoxTables.Text = "Tables";
            // 
            // FormDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 470);
            this.Controls.Add(this.splitContainer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormDatabase";
            this.Text = "FormDatabase";
            this.splitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private SplitContainer splitContainer;
        private GroupBox groupBoxTables;
        private GroupBox groupBoxDifferences;
        private Panel panel1;
    }
}