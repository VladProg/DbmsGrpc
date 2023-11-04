using System;
using System.Drawing;
using System.Windows.Forms;

namespace DbmsWcfClient
{
    public partial class FormCreateTable : Form
    {
        public FormCreateTable()
        {
            InitializeComponent();
        }

        private void buttonSaveTable_Click(object sender, EventArgs e)
        {
            FormDatabase formDatabase = Parent.FindForm() as FormDatabase;
            if (formDatabase == null)
                return;
            formDatabase.CreateTable();
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null)
                return;
            Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font);
            textBox.Width = Math.Max(size.Width + 10, 60);
        }

        private void comboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null)
                return;

            FlowLayoutPanel flowLayoutPanelCreateColumn = comboBox.Parent.Parent.Parent as FlowLayoutPanel;
            if (flowLayoutPanelCreateColumn == null)
                return;

            if (comboBox.SelectedIndex == 5)
            {
                flowLayoutPanelCreateColumn.Controls[2].Visible = true;
                flowLayoutPanelCreateColumn.Controls[3].Visible = true;
                flowLayoutPanelCreateColumn.Controls[4].Visible = true;
            }
            else
            {
                flowLayoutPanelCreateColumn.Controls[2].Visible = false;
                flowLayoutPanelCreateColumn.Controls[3].Visible = false;
                flowLayoutPanelCreateColumn.Controls[4].Visible = false;
            }
        }

        private void numericUpDownRGB1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDownRGB1 = sender as NumericUpDown;
            if (numericUpDownRGB1 == null)
                return;

            FlowLayoutPanel flowLayoutPanelRGB = numericUpDownRGB1.Parent as FlowLayoutPanel;
            if (flowLayoutPanelRGB == null)
                return;

            NumericUpDown numericUpDownRGB2 = flowLayoutPanelRGB.Controls[2] as NumericUpDown;
            if (numericUpDownRGB2 == null)
                return;

            numericUpDownRGB2.Minimum = numericUpDownRGB1.Value;
        }

        private void numericUpDownRGB2_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown numericUpDownRGB2 = sender as NumericUpDown;
            if (numericUpDownRGB2 == null)
                return;

            FlowLayoutPanel flowLayoutPanelRGB = numericUpDownRGB2.Parent as FlowLayoutPanel;
            if (flowLayoutPanelRGB == null)
                return;

            NumericUpDown numericUpDownRGB1 = flowLayoutPanelRGB.Controls[0] as NumericUpDown;
            if (numericUpDownRGB1 == null)
                return;

            numericUpDownRGB1.Maximum = numericUpDownRGB2.Value;
        }

        private void enumerateColumns()
        {
            for (int i = 0; i < flowLayoutPanelColumns.Controls.Count; i++)
            {
                flowLayoutPanelColumns.Controls[i].Text = "Column #" + (i + 1);
                flowLayoutPanelColumns.Controls[i].Controls[0].Controls[5].Controls[0].Controls[0].Enabled = i != 0;
                flowLayoutPanelColumns.Controls[i].Controls[0].Controls[5].Controls[0].Controls[1].Enabled = i != flowLayoutPanelColumns.Controls.Count - 1;
            }
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            Button buttonMoveUp = sender as Button;
            if (buttonMoveUp == null)
                return;

            GroupBox groupBoxCreateColumn = buttonMoveUp.Parent.Parent.Parent.Parent as GroupBox;
            if (groupBoxCreateColumn == null)
                return;

            int index = flowLayoutPanelColumns.Controls.GetChildIndex(groupBoxCreateColumn);
            if (index == 0)
                return;
            flowLayoutPanelColumns.Controls.SetChildIndex(groupBoxCreateColumn, index - 1);
            enumerateColumns();
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            Button buttonMoveDown = sender as Button;
            if (buttonMoveDown == null)
                return;

            GroupBox groupBoxCreateColumn = buttonMoveDown.Parent.Parent.Parent.Parent as GroupBox;
            if (groupBoxCreateColumn == null)
                return;

            int index = flowLayoutPanelColumns.Controls.GetChildIndex(groupBoxCreateColumn);
            if (index == flowLayoutPanelColumns.Controls.Count - 1)
                return;
            flowLayoutPanelColumns.Controls.SetChildIndex(groupBoxCreateColumn, index + 1);
            enumerateColumns();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            Button buttonRemove = sender as Button;
            if (buttonRemove == null)
                return;

            GroupBox groupBoxCreateColumn = buttonRemove.Parent.Parent.Parent.Parent as GroupBox;
            if (groupBoxCreateColumn == null)
                return;

            flowLayoutPanelColumns.Controls.Remove(groupBoxCreateColumn);
            enumerateColumns();
        }

        private void buttonAddColumn_Click(object sender, EventArgs e)
        {
            FormCreateColumn formCreateColumn = new FormCreateColumn();
            formCreateColumn.textBoxName.TextChanged += textBox_TextChanged;
            formCreateColumn.comboBoxType.SelectedIndexChanged += comboBoxType_SelectedIndexChanged;
            formCreateColumn.comboBoxType.SelectedIndex = 0;
            formCreateColumn.numericUpDownR1.ValueChanged += numericUpDownRGB1_ValueChanged;
            formCreateColumn.numericUpDownR2.ValueChanged += numericUpDownRGB2_ValueChanged;
            formCreateColumn.numericUpDownG1.ValueChanged += numericUpDownRGB1_ValueChanged;
            formCreateColumn.numericUpDownG2.ValueChanged += numericUpDownRGB2_ValueChanged;
            formCreateColumn.numericUpDownB1.ValueChanged += numericUpDownRGB1_ValueChanged;
            formCreateColumn.numericUpDownB2.ValueChanged += numericUpDownRGB2_ValueChanged;
            formCreateColumn.buttonMoveUp.Click += buttonMoveUp_Click;
            formCreateColumn.buttonMoveDown.Click += buttonMoveDown_Click;
            formCreateColumn.buttonRemove.Click += buttonRemove_Click;
            GroupBox groupBoxCreateColumn = formCreateColumn.groupBoxCreateColumn;
            formCreateColumn.Controls.Remove(groupBoxCreateColumn);
            flowLayoutPanelColumns.Controls.Add(groupBoxCreateColumn);
            formCreateColumn.Dispose();
            enumerateColumns();
        }
    }
}
