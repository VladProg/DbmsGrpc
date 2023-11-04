using System.Drawing;
using System.Windows.Forms;

namespace DbmsWcfClient
{
    partial class FormCreateColumn
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
            groupBoxCreateColumn = new GroupBox();
            flowLayoutPanelCreateColumn = new FlowLayoutPanel();
            groupBoxName = new GroupBox();
            flowLayoutPanelName = new FlowLayoutPanel();
            textBoxName = new TextBox();
            groupBoxType = new GroupBox();
            flowLayoutPanelType = new FlowLayoutPanel();
            comboBoxType = new ComboBox();
            groupBoxR = new GroupBox();
            flowLayoutPanelR = new FlowLayoutPanel();
            numericUpDownR1 = new NumericUpDown();
            labelR = new Label();
            numericUpDownR2 = new NumericUpDown();
            groupBoxG = new GroupBox();
            flowLayoutPanelG = new FlowLayoutPanel();
            numericUpDownG1 = new NumericUpDown();
            labelG = new Label();
            numericUpDownG2 = new NumericUpDown();
            groupBoxB = new GroupBox();
            flowLayoutPanelB = new FlowLayoutPanel();
            numericUpDownB1 = new NumericUpDown();
            labelB = new Label();
            numericUpDownB2 = new NumericUpDown();
            groupBoxActions = new GroupBox();
            flowLayoutPanelActions = new FlowLayoutPanel();
            buttonMoveUp = new Button();
            buttonMoveDown = new Button();
            buttonRemove = new Button();
            groupBoxCreateColumn.SuspendLayout();
            flowLayoutPanelCreateColumn.SuspendLayout();
            groupBoxName.SuspendLayout();
            flowLayoutPanelName.SuspendLayout();
            groupBoxType.SuspendLayout();
            flowLayoutPanelType.SuspendLayout();
            groupBoxR.SuspendLayout();
            flowLayoutPanelR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownR1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownR2).BeginInit();
            groupBoxG.SuspendLayout();
            flowLayoutPanelG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownG1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownG2).BeginInit();
            groupBoxB.SuspendLayout();
            flowLayoutPanelB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB2).BeginInit();
            groupBoxActions.SuspendLayout();
            flowLayoutPanelActions.SuspendLayout();
            SuspendLayout();
            // 
            // groupBoxCreateColumn
            // 
            groupBoxCreateColumn.AutoSize = true;
            groupBoxCreateColumn.Controls.Add(flowLayoutPanelCreateColumn);
            groupBoxCreateColumn.Location = new Point(25, 73);
            groupBoxCreateColumn.Name = "groupBoxCreateColumn";
            groupBoxCreateColumn.Size = new Size(904, 94);
            groupBoxCreateColumn.TabIndex = 0;
            groupBoxCreateColumn.TabStop = false;
            // 
            // flowLayoutPanelCreateColumn
            // 
            flowLayoutPanelCreateColumn.AutoSize = true;
            flowLayoutPanelCreateColumn.Controls.Add(groupBoxName);
            flowLayoutPanelCreateColumn.Controls.Add(groupBoxType);
            flowLayoutPanelCreateColumn.Controls.Add(groupBoxR);
            flowLayoutPanelCreateColumn.Controls.Add(groupBoxG);
            flowLayoutPanelCreateColumn.Controls.Add(groupBoxB);
            flowLayoutPanelCreateColumn.Controls.Add(groupBoxActions);
            flowLayoutPanelCreateColumn.Dock = DockStyle.Fill;
            flowLayoutPanelCreateColumn.Location = new Point(3, 23);
            flowLayoutPanelCreateColumn.Name = "flowLayoutPanelCreateColumn";
            flowLayoutPanelCreateColumn.Size = new Size(898, 68);
            flowLayoutPanelCreateColumn.TabIndex = 0;
            // 
            // groupBoxName
            // 
            groupBoxName.AutoSize = true;
            groupBoxName.Controls.Add(flowLayoutPanelName);
            groupBoxName.Location = new Point(3, 3);
            groupBoxName.Name = "groupBoxName";
            groupBoxName.Size = new Size(72, 59);
            groupBoxName.TabIndex = 3;
            groupBoxName.TabStop = false;
            groupBoxName.Text = "Name";
            // 
            // flowLayoutPanelName
            // 
            flowLayoutPanelName.AutoSize = true;
            flowLayoutPanelName.Controls.Add(textBoxName);
            flowLayoutPanelName.Dock = DockStyle.Fill;
            flowLayoutPanelName.Location = new Point(3, 23);
            flowLayoutPanelName.Name = "flowLayoutPanelName";
            flowLayoutPanelName.Size = new Size(66, 33);
            flowLayoutPanelName.TabIndex = 0;
            // 
            // textBoxName
            // 
            textBoxName.Location = new Point(3, 3);
            textBoxName.Name = "textBoxName";
            textBoxName.Size = new Size(60, 27);
            textBoxName.TabIndex = 2;
            // 
            // groupBoxType
            // 
            groupBoxType.AutoSize = true;
            groupBoxType.Controls.Add(flowLayoutPanelType);
            groupBoxType.Location = new Point(81, 3);
            groupBoxType.Name = "groupBoxType";
            groupBoxType.Size = new Size(102, 60);
            groupBoxType.TabIndex = 3;
            groupBoxType.TabStop = false;
            groupBoxType.Text = "Type";
            // 
            // flowLayoutPanelType
            // 
            flowLayoutPanelType.AutoSize = true;
            flowLayoutPanelType.Controls.Add(comboBoxType);
            flowLayoutPanelType.Dock = DockStyle.Fill;
            flowLayoutPanelType.Location = new Point(3, 23);
            flowLayoutPanelType.Name = "flowLayoutPanelType";
            flowLayoutPanelType.Size = new Size(96, 34);
            flowLayoutPanelType.TabIndex = 0;
            // 
            // comboBoxType
            // 
            comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxType.FormattingEnabled = true;
            comboBoxType.Items.AddRange(new object[] { "Integer", "Real", "Char", "String", "Color", "ColorInvl" });
            comboBoxType.Location = new Point(3, 3);
            comboBoxType.Name = "comboBoxType";
            comboBoxType.Size = new Size(90, 28);
            comboBoxType.TabIndex = 2;
            // 
            // groupBoxR
            // 
            groupBoxR.AutoSize = true;
            groupBoxR.Controls.Add(flowLayoutPanelR);
            groupBoxR.Location = new Point(189, 3);
            groupBoxR.Name = "groupBoxR";
            groupBoxR.Size = new Size(139, 59);
            groupBoxR.TabIndex = 3;
            groupBoxR.TabStop = false;
            groupBoxR.Text = "R interval";
            groupBoxR.Visible = false;
            // 
            // flowLayoutPanelR
            // 
            flowLayoutPanelR.AutoSize = true;
            flowLayoutPanelR.Controls.Add(numericUpDownR1);
            flowLayoutPanelR.Controls.Add(labelR);
            flowLayoutPanelR.Controls.Add(numericUpDownR2);
            flowLayoutPanelR.Dock = DockStyle.Fill;
            flowLayoutPanelR.Location = new Point(3, 23);
            flowLayoutPanelR.Name = "flowLayoutPanelR";
            flowLayoutPanelR.Size = new Size(133, 33);
            flowLayoutPanelR.TabIndex = 0;
            // 
            // numericUpDownR1
            // 
            numericUpDownR1.Location = new Point(3, 3);
            numericUpDownR1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDownR1.Name = "numericUpDownR1";
            numericUpDownR1.Size = new Size(50, 27);
            numericUpDownR1.TabIndex = 0;
            // 
            // labelR
            // 
            labelR.AutoSize = true;
            labelR.Location = new Point(59, 0);
            labelR.MinimumSize = new Size(0, 27);
            labelR.Name = "labelR";
            labelR.Size = new Size(15, 27);
            labelR.TabIndex = 1;
            labelR.Text = "..";
            labelR.TextAlign = ContentAlignment.BottomLeft;
            // 
            // numericUpDownR2
            // 
            numericUpDownR2.Location = new Point(80, 3);
            numericUpDownR2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDownR2.Name = "numericUpDownR2";
            numericUpDownR2.Size = new Size(50, 27);
            numericUpDownR2.TabIndex = 0;
            numericUpDownR2.Value = new decimal(new int[] { 255, 0, 0, 0 });
            // 
            // groupBoxG
            // 
            groupBoxG.AutoSize = true;
            groupBoxG.Controls.Add(flowLayoutPanelG);
            groupBoxG.Location = new Point(334, 3);
            groupBoxG.Name = "groupBoxG";
            groupBoxG.Size = new Size(139, 59);
            groupBoxG.TabIndex = 3;
            groupBoxG.TabStop = false;
            groupBoxG.Text = "G interval";
            groupBoxG.Visible = false;
            // 
            // flowLayoutPanelG
            // 
            flowLayoutPanelG.AutoSize = true;
            flowLayoutPanelG.Controls.Add(numericUpDownG1);
            flowLayoutPanelG.Controls.Add(labelG);
            flowLayoutPanelG.Controls.Add(numericUpDownG2);
            flowLayoutPanelG.Dock = DockStyle.Fill;
            flowLayoutPanelG.Location = new Point(3, 23);
            flowLayoutPanelG.Name = "flowLayoutPanelG";
            flowLayoutPanelG.Size = new Size(133, 33);
            flowLayoutPanelG.TabIndex = 0;
            // 
            // numericUpDownG1
            // 
            numericUpDownG1.Location = new Point(3, 3);
            numericUpDownG1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDownG1.Name = "numericUpDownG1";
            numericUpDownG1.Size = new Size(50, 27);
            numericUpDownG1.TabIndex = 0;
            // 
            // labelG
            // 
            labelG.AutoSize = true;
            labelG.Location = new Point(59, 0);
            labelG.MinimumSize = new Size(0, 27);
            labelG.Name = "labelG";
            labelG.Size = new Size(15, 27);
            labelG.TabIndex = 1;
            labelG.Text = "..";
            labelG.TextAlign = ContentAlignment.BottomLeft;
            // 
            // numericUpDownG2
            // 
            numericUpDownG2.Location = new Point(80, 3);
            numericUpDownG2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDownG2.Name = "numericUpDownG2";
            numericUpDownG2.Size = new Size(50, 27);
            numericUpDownG2.TabIndex = 0;
            numericUpDownG2.Value = new decimal(new int[] { 255, 0, 0, 0 });
            // 
            // groupBoxB
            // 
            groupBoxB.AutoSize = true;
            groupBoxB.Controls.Add(flowLayoutPanelB);
            groupBoxB.Location = new Point(479, 3);
            groupBoxB.Name = "groupBoxB";
            groupBoxB.Size = new Size(139, 59);
            groupBoxB.TabIndex = 3;
            groupBoxB.TabStop = false;
            groupBoxB.Text = "B interval";
            groupBoxB.Visible = false;
            // 
            // flowLayoutPanelB
            // 
            flowLayoutPanelB.AutoSize = true;
            flowLayoutPanelB.Controls.Add(numericUpDownB1);
            flowLayoutPanelB.Controls.Add(labelB);
            flowLayoutPanelB.Controls.Add(numericUpDownB2);
            flowLayoutPanelB.Dock = DockStyle.Fill;
            flowLayoutPanelB.Location = new Point(3, 23);
            flowLayoutPanelB.Name = "flowLayoutPanelB";
            flowLayoutPanelB.Size = new Size(133, 33);
            flowLayoutPanelB.TabIndex = 0;
            // 
            // numericUpDownB1
            // 
            numericUpDownB1.Location = new Point(3, 3);
            numericUpDownB1.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDownB1.Name = "numericUpDownB1";
            numericUpDownB1.Size = new Size(50, 27);
            numericUpDownB1.TabIndex = 0;
            // 
            // labelB
            // 
            labelB.AutoSize = true;
            labelB.Location = new Point(59, 0);
            labelB.MinimumSize = new Size(0, 27);
            labelB.Name = "labelB";
            labelB.Size = new Size(15, 27);
            labelB.TabIndex = 1;
            labelB.Text = "..";
            labelB.TextAlign = ContentAlignment.BottomLeft;
            // 
            // numericUpDownB2
            // 
            numericUpDownB2.Location = new Point(80, 3);
            numericUpDownB2.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            numericUpDownB2.Name = "numericUpDownB2";
            numericUpDownB2.Size = new Size(50, 27);
            numericUpDownB2.TabIndex = 0;
            numericUpDownB2.Value = new decimal(new int[] { 255, 0, 0, 0 });
            // 
            // groupBoxActions
            // 
            groupBoxActions.AutoSize = true;
            groupBoxActions.Controls.Add(flowLayoutPanelActions);
            groupBoxActions.Location = new Point(624, 3);
            groupBoxActions.Name = "groupBoxActions";
            groupBoxActions.Size = new Size(271, 62);
            groupBoxActions.TabIndex = 3;
            groupBoxActions.TabStop = false;
            groupBoxActions.Text = "Actions";
            // 
            // flowLayoutPanelActions
            // 
            flowLayoutPanelActions.AutoSize = true;
            flowLayoutPanelActions.Controls.Add(buttonMoveUp);
            flowLayoutPanelActions.Controls.Add(buttonMoveDown);
            flowLayoutPanelActions.Controls.Add(buttonRemove);
            flowLayoutPanelActions.Dock = DockStyle.Fill;
            flowLayoutPanelActions.Location = new Point(3, 23);
            flowLayoutPanelActions.Name = "flowLayoutPanelActions";
            flowLayoutPanelActions.Size = new Size(265, 36);
            flowLayoutPanelActions.TabIndex = 0;
            // 
            // buttonMoveUp
            // 
            buttonMoveUp.AutoSize = true;
            buttonMoveUp.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            buttonMoveUp.Location = new Point(3, 3);
            buttonMoveUp.Name = "buttonMoveUp";
            buttonMoveUp.Size = new Size(77, 30);
            buttonMoveUp.TabIndex = 2;
            buttonMoveUp.Text = "Move up";
            buttonMoveUp.UseVisualStyleBackColor = true;
            // 
            // buttonMoveDown
            // 
            buttonMoveDown.AutoSize = true;
            buttonMoveDown.Location = new Point(86, 3);
            buttonMoveDown.Name = "buttonMoveDown";
            buttonMoveDown.Size = new Size(97, 30);
            buttonMoveDown.TabIndex = 2;
            buttonMoveDown.Text = "Move down";
            buttonMoveDown.UseVisualStyleBackColor = true;
            // 
            // buttonRemove
            // 
            buttonRemove.AutoSize = true;
            buttonRemove.BackgroundImageLayout = ImageLayout.Stretch;
            buttonRemove.Location = new Point(189, 3);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(73, 30);
            buttonRemove.TabIndex = 2;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            // 
            // FormCreateColumn
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(971, 450);
            Controls.Add(groupBoxCreateColumn);
            Name = "FormCreateColumn";
            Text = "FormCreateColumn";
            groupBoxCreateColumn.ResumeLayout(false);
            groupBoxCreateColumn.PerformLayout();
            flowLayoutPanelCreateColumn.ResumeLayout(false);
            flowLayoutPanelCreateColumn.PerformLayout();
            groupBoxName.ResumeLayout(false);
            groupBoxName.PerformLayout();
            flowLayoutPanelName.ResumeLayout(false);
            flowLayoutPanelName.PerformLayout();
            groupBoxType.ResumeLayout(false);
            groupBoxType.PerformLayout();
            flowLayoutPanelType.ResumeLayout(false);
            groupBoxR.ResumeLayout(false);
            groupBoxR.PerformLayout();
            flowLayoutPanelR.ResumeLayout(false);
            flowLayoutPanelR.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownR1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownR2).EndInit();
            groupBoxG.ResumeLayout(false);
            groupBoxG.PerformLayout();
            flowLayoutPanelG.ResumeLayout(false);
            flowLayoutPanelG.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownG1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownG2).EndInit();
            groupBoxB.ResumeLayout(false);
            groupBoxB.PerformLayout();
            flowLayoutPanelB.ResumeLayout(false);
            flowLayoutPanelB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownB2).EndInit();
            groupBoxActions.ResumeLayout(false);
            groupBoxActions.PerformLayout();
            flowLayoutPanelActions.ResumeLayout(false);
            flowLayoutPanelActions.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public GroupBox groupBoxCreateColumn;
        public FlowLayoutPanel flowLayoutPanelCreateColumn;
        public GroupBox groupBoxName;
        public FlowLayoutPanel flowLayoutPanelName;
        public TextBox textBoxName;
        public GroupBox groupBoxType;
        public FlowLayoutPanel flowLayoutPanelType;
        public ComboBox comboBoxType;
        public GroupBox groupBoxR;
        public FlowLayoutPanel flowLayoutPanelR;
        public NumericUpDown numericUpDownR1;
        public Label labelR;
        public NumericUpDown numericUpDownR2;
        public GroupBox groupBoxG;
        public FlowLayoutPanel flowLayoutPanelG;
        public NumericUpDown numericUpDownG1;
        public Label labelG;
        public NumericUpDown numericUpDownG2;
        public GroupBox groupBoxActions;
        public FlowLayoutPanel flowLayoutPanelActions;
        public GroupBox groupBoxB;
        public FlowLayoutPanel flowLayoutPanelB;
        public NumericUpDown numericUpDownB1;
        public Label labelB;
        public NumericUpDown numericUpDownB2;
        public Button buttonMoveUp;
        public Button buttonMoveDown;
        public Button buttonRemove;
    }
}