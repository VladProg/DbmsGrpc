using System;
using System.Windows.Forms;

public class FormStartDialog : Form
{
    private TextBox urlTextBox;
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
        Height = 240;

        Label urlLabel = new Label
        {
            Text = "Server URL:",
            Top = 10,
            Left = 10,
            Width = 160
        };
        Controls.Add(urlLabel);

        urlTextBox = new TextBox
        {
            Top = 10,
            Left = 170,
            Width = 190,
            Text = "http://localhost:5000"
        };
        Controls.Add(urlTextBox);

        Label chooseActionLabel = new Label
        {
            Text = "Choose the action:",
            Top = 50,
            Left = 10,
            Width = 1000
        };
        Controls.Add(chooseActionLabel);

        AddActionRow("Open database", Action.OPEN, 80, out openDbTextBox);
        AddActionRow("Create database", Action.CREATE, 120, out createDbTextBox);
        AddActionRow("Delete database", Action.DELETE, 160, out deleteDbTextBox);
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

    public static (Action action, string text, string url)? ShowStartDialog()
    {
        using (FormStartDialog dialog = new FormStartDialog())
        {
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return (dialog.SelectedAction, dialog.InputText, dialog.urlTextBox.Text);
            }
        }
        return null;
    }
}
