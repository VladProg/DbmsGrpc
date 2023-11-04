using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;

namespace DbmsWcfClient
{
    public partial class FormDatabase : Form
    {
        private readonly DbmsGrpc.DbmsProcessor.DbmsProcessorClient client;

        private readonly string dbName;
        private FormCreateTable? formCreateTable = null;

        private IEnumerable<FormTable> AllFormsTable => splitContainer.Panel2.Controls.OfType<FormTable>();

        private FormTable FindFormTable(int id) =>
            AllFormsTable.FirstOrDefault(form => form.TableInfo.Id == id);

        public FormDatabase(DbmsGrpc.DbmsProcessor.DbmsProcessorClient client, string dbName)
        {
            InitializeComponent();
            this.client = client;
            this.dbName = dbName;
            SetText();
            ListTables();
        }

        private void SetText()
        {
            Text = dbName + " - Database Management System";
        }

        private void buttonCreateTable_Click(object sender, EventArgs e)
        {
            if (formCreateTable == null || formCreateTable.IsDisposed)
            {
                formCreateTable = new FormCreateTable()
                {
                    TopLevel = false
                };
                splitContainer.Panel2.Controls.Add(formCreateTable);
                formCreateTable.WindowState = FormWindowState.Maximized;
                formCreateTable.BringToFront();
                formCreateTable.Show();
            }
            else
            {
                formCreateTable.WindowState = FormWindowState.Maximized;
                formCreateTable.BringToFront();
            }
        }

        public void ListTables(int? closedId = null)
        {
            groupBoxTables.SuspendLayout();
            groupBoxDifferences.SuspendLayout();
            groupBoxTables.Controls.Clear();
            groupBoxDifferences.Controls.Clear();
            var databaseInfo = client.GetDatabase(new() { DbName = dbName });
            foreach (var table in databaseInfo.Tables.Reverse())
            {
                LinkLabel linkLabelTable = new()
                {
                    Text = table.Name + "  ×",
                    AutoSize = true,
                    AutoEllipsis = true,
                    Dock = DockStyle.Top
                };
                if ((!closedId.HasValue || closedId.Value != table.Id) &&
                        FindFormTable(table.Id) != null)
                    linkLabelTable.LinkColor = System.Drawing.Color.Purple;
                linkLabelTable.Links.Add(0, table.Name.Length, "Name");
                linkLabelTable.Links.Add(table.Name.Length + 2, 1, "Remove");
                linkLabelTable.LinkClicked += (sender, e) =>
                {
                    if (e.Link.LinkData.ToString() == "Remove")
                        RemoveTable(table);
                    else
                        ShowTable(table);
                };
                groupBoxTables.Controls.Add(linkLabelTable);
            }
            foreach (var difference in databaseInfo.TableDifferences.Reverse())
            {
                LinkLabel linkLabelTable = new()
                {
                    Text = difference.Name,
                    AutoSize = true,
                    AutoEllipsis = true,
                    Dock = DockStyle.Top
                };
                if ((!closedId.HasValue || closedId.Value != difference.Id) &&
                        FindFormTable(difference.Id) != null)
                    linkLabelTable.LinkColor = System.Drawing.Color.Purple;
                linkLabelTable.LinkClicked += (sender, e) => ShowTable(difference);
                groupBoxDifferences.Controls.Add(linkLabelTable);
            }
            groupBoxTables.ResumeLayout();
            groupBoxDifferences.ResumeLayout();
        }

        private void RemoveTable(DbmsGrpc.Messages.TableInfo table)
        {
            if (MessageBox.Show($"Are you sure you want to remove table \"{table.Name}\"?", "Attempt to remove table", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;
            foreach (FormTable form in AllFormsTable.ToArray())
                if (form.TableInfo.Id == table.Id ||
                        form.TableInfo.TableDifferenceInfo is not null &&
                        (form.TableInfo.TableDifferenceInfo.LeftTableInfo.Id == table.Id ||
                         form.TableInfo.TableDifferenceInfo.RightTableInfo.Id == table.Id))
                    form.Close();
            client.RemoveTable(new() { DbName=dbName, TableId=table.Id });
            ListTables();
        }

        private void ShowTable(DbmsGrpc.Messages.TableInfo tableInfo)
        {
            FormTable formTable = FindFormTable(tableInfo.Id);
            if (formTable != null)
            {
                formTable.WindowState = FormWindowState.Maximized;
                formTable.BringToFront();
            }
            else
            {
                formTable = new FormTable(client, dbName, tableInfo)
                {
                    TopLevel = false
                };
                splitContainer.Panel2.Controls.Add(formTable);
                formTable.WindowState = FormWindowState.Maximized;
                formTable.BringToFront();
                formTable.Show();
            }
            ListTables();
        }

        public void CreateTable()
        {
            if (formCreateTable == null)
                return;
            if (formCreateTable.textBoxTableName.Text == "")
            {
                MessageBox.Show("Table name must be non-empty", "Cannot create table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (formCreateTable.flowLayoutPanelColumns.Controls.Count == 0)
            {
                MessageBox.Show("Table must have at least one column", "Cannot create table", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            client.AddTable(new() {
                DbName=dbName,
                TableName=formCreateTable.textBoxTableName.Text,
                Columns ={from GroupBox groupBoxCreateColumn
                 in formCreateTable.flowLayoutPanelColumns.Controls
                 let name = groupBoxCreateColumn.Controls[0].Controls[0].Controls[0].Controls[0].Text
                 let typeIndex = (groupBoxCreateColumn.Controls[0].Controls[1].Controls[0].Controls[0] as ComboBox)!.SelectedIndex
                 let type =
                    typeIndex == 0 ? new DbmsGrpc.Messages.Types.Type() { Integer = new() } :
                    typeIndex == 1 ? new DbmsGrpc.Messages.Types.Type() { Real = new() } :
                    typeIndex == 2 ? new DbmsGrpc.Messages.Types.Type() { Char = new() } :
                    typeIndex == 3 ? new DbmsGrpc.Messages.Types.Type() { String = new() } :
                    typeIndex == 4 ? new DbmsGrpc.Messages.Types.Type() { Color = new() } :
                    typeIndex == 5 ? new DbmsGrpc.Messages.Types.Type()
                    {
                        ColorInvl = new()
                        {
                            R1 = (byte)(groupBoxCreateColumn.Controls[0].Controls[2].Controls[0].Controls[0] as NumericUpDown)!.Value,
                            R2 = (byte)(groupBoxCreateColumn.Controls[0].Controls[2].Controls[0].Controls[2] as NumericUpDown)!.Value,
                            G1 = (byte)(groupBoxCreateColumn.Controls[0].Controls[3].Controls[0].Controls[0] as NumericUpDown)!.Value,
                            G2 = (byte)(groupBoxCreateColumn.Controls[0].Controls[3].Controls[0].Controls[2] as NumericUpDown)!.Value,
                            B1 = (byte)(groupBoxCreateColumn.Controls[0].Controls[4].Controls[0].Controls[0] as NumericUpDown)!.Value,
                            B2 = (byte)(groupBoxCreateColumn.Controls[0].Controls[4].Controls[0].Controls[2] as NumericUpDown)!.Value
                        }
                    } :
                    new DbmsGrpc.Messages.Types.Type()
                 select new DbmsGrpc.Messages.Column() { Name=name, Type=type }
                 }
            });
            splitContainer.Panel2.Controls.Remove(formCreateTable);
            formCreateTable.Dispose();
            formCreateTable = null;
            ListTables();
        }

        int? splitContainer_Panel2_Width, splitContainer_Panel2_Height = null;

        private void splitContainer_Panel2_SizeChanged(object sender, EventArgs e)
        {
            splitContainer_Panel2_Width ??= splitContainer.Panel2.Width;
            splitContainer_Panel2_Height ??= splitContainer.Panel2.Height;
            foreach (Control control in splitContainer.Panel2.Controls)
            {
                if (control is not Form form)
                    continue;
                if (form.Left < 0 && splitContainer.Panel2.Width > splitContainer_Panel2_Width)
                    form.Left += splitContainer.Panel2.Width - splitContainer_Panel2_Width.Value;
                if (form.Top < 0 && splitContainer.Panel2.Height > splitContainer_Panel2_Height)
                    form.Top += splitContainer.Panel2.Height - splitContainer_Panel2_Height.Value;
                if (form.Left + form.Width > splitContainer.Panel2.Width)
                    form.Width = splitContainer.Panel2.Width - form.Left;
                if (form.Left + form.Width > splitContainer.Panel2.Width)
                    form.Left = splitContainer.Panel2.Width - form.Width;
                if (form.Top + form.Height > splitContainer.Panel2.Height)
                    form.Height = splitContainer.Panel2.Height - form.Top;
                if (form.Top + form.Height > splitContainer.Panel2.Height)
                    form.Top = splitContainer.Panel2.Height - form.Height;
                if (form.WindowState == FormWindowState.Maximized)
                {
                    int ind = splitContainer.Panel2.Controls.IndexOf(form);
                    form.WindowState = FormWindowState.Normal;
                    form.WindowState = FormWindowState.Maximized;
                    splitContainer.Panel2.Controls.SetChildIndex(form, ind);
                }
            }
            splitContainer_Panel2_Width = splitContainer.Panel2.Width;
            splitContainer_Panel2_Height = splitContainer.Panel2.Height;
        }

        public void RefreshDifferences(int id)
        {
            foreach (FormTable form in AllFormsTable)
                if (form.TableInfo.TableDifferenceInfo is not null &&
                        (form.TableInfo.TableDifferenceInfo.LeftTableInfo.Id == id || form.TableInfo.TableDifferenceInfo.RightTableInfo.Id == id))
                    form.RefreshRows();
        }
    }
}
