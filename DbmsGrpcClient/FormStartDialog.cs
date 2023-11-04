using System;
using System.Windows.Forms;

public class FormStartDialog : Form
{
    private TextBox openDbTextBox;
    private TextBox createDbTextBox;
    private TextBox deleteDbTextBox;

    public enum Action { OPEN, CREATE, DELETE }

    public Action SelectedAction { get; private set; }
    public string InputText { get; private set; }

    public FormStartDialog()
    {
        Text = "DBMS";
        Width = 400;
        Height = 200;

        Label chooseActionLabel = new Label
        {
            Text = "Choose the action:",
            Top = 10,
            Left = 10,
            Width = 1000
        };
        Controls.Add(chooseActionLabel);

        AddActionRow("Open database", Action.OPEN, 40, out openDbTextBox);
        AddActionRow("Create database", Action.CREATE, 80, out createDbTextBox);
        AddActionRow("Delete database", Action.DELETE, 120, out deleteDbTextBox);
    }

    private void AddActionRow(string actionText, Action action, int top, out TextBox textBox)
    {
        Label label = new Label
        {
            Text = actionText,
            Top = top,
            Left = 10,
            Width = 150
        };
        Controls.Add(label);

        textBox = new TextBox
        {
            Top = top,
            Left = 170,
            Width = 100
        };
        Controls.Add(textBox);

        Button okButton = new Button
        {
            Text = "OK",
            Top = top,
            Left = 280,
            Width = 80
        };
        var localTextBox = textBox;
        okButton.Click += (s, e) =>
        {
            SelectedAction = action;
            InputText = localTextBox.Text;
            DialogResult = DialogResult.OK;
        };
        Controls.Add(okButton);
        textBox.KeyDown += (sender, e) =>
        {
            if (e.KeyCode == Keys.Enter)
            {
                okButton.PerformClick();
                e.SuppressKeyPress = true; 
            }
        };
    }

    public static (Action action, string text)? ShowStartDialog()
    {
        using (FormStartDialog dialog = new FormStartDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return (dialog.SelectedAction, dialog.InputText);
            }
        }
        return null;
    }
}
