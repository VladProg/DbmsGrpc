using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DbmsWcfClient
{
    public partial class FormTable : Form
    {
        private readonly DbmsGrpc.DbmsProcessor.DbmsProcessorClient client;
        private readonly string dbName;
        public readonly DbmsGrpc.Messages.TableInfo TableInfo;

        public FormTable(DbmsGrpc.DbmsProcessor.DbmsProcessorClient client, string dbName, DbmsGrpc.Messages.TableInfo tableInfo)
        {
            InitializeComponent();
            this.client = client;
            this.dbName = dbName;
            TableInfo = tableInfo;
            Text = TableInfo.Name;
            RefreshRows();
            if (TableInfo.TableDifferenceInfo is not null)
            {
                dataGridView.ReadOnly = true;
                dataGridView.AllowUserToDeleteRows = false;
                dataGridView.AllowUserToAddRows = false;
            }
        }

        public void RefreshRows()
        {
            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();
            var table = client.GetTable(new() { DbName=dbName, TableId=TableInfo.Id });
            foreach (var column in table.Columns)
                dataGridView.Columns.Add("", column.Name + "\n" + column.Type.ToStr);
            foreach (DataGridViewColumn column in dataGridView.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            var sortedIds = table.Rows.Keys.OrderBy(id => id);
            foreach (var id in sortedIds)
                dataGridView.Rows[dataGridView.Rows.Add(table.Rows[id].Cells.ToArray())].Tag = id;
        }

        private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex == dataGridView.NewRowIndex || !dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].IsInEditMode)
                return;
            try
            {
                client.ValidateCell(new() { DbName=dbName, TableId=TableInfo.Id, ColumnId=e.ColumnIndex, Value=e.FormattedValue.ToString() });
            }
            catch (Exception ex)
            {
                e.Cancel = true;
                MessageBox.Show(ex.Message, "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (e.RowIndex == dataGridView.NewRowIndex)
                return;
            try
            {
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                    client.ValidateCell(new() {DbName= dbName, TableId=TableInfo.Id, ColumnId=i, Value=dataGridView.Rows[e.RowIndex].Cells[i].Value?.ToString() ?? "" });
            }
            catch
            {
                e.Cancel = true;
                MessageBox.Show("Fill all cells to create row (or remove the entire row)", "Cannot create row", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow dgvRow = dataGridView.Rows[e.RowIndex];
            int? rowId = dgvRow.Tag as int?;
            if (rowId == null)
            {
                try
                {
                    string[] cells = new string[dataGridView.Columns.Count];
                    for (int i = 0; i < dataGridView.Columns.Count; i++)
                        cells[i] = dgvRow.Cells[i].Value?.ToString() ?? "";
                    dgvRow.Tag = client.AddRow(new() { DbName = dbName, TableId = TableInfo.Id, Cells = { cells } }).RowId;
                    if (Parent.FindForm() is FormDatabase parentForm)
                        parentForm.RefreshDifferences(TableInfo.Id);
                }
                catch { }
            }
            else
            {
                DataGridViewCell dgvCell = dgvRow.Cells[e.ColumnIndex];
                client.UpdateCell(new() { DbName=dbName, TableId=TableInfo.Id, RowId=rowId.Value, ColumnId=e.ColumnIndex, Value=dgvCell.Value?.ToString() ?? "" });
                if (Parent.FindForm() is FormDatabase parentForm)
                    parentForm.RefreshDifferences(TableInfo.Id);
            }
        }

        private void dataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            int? dbRow = e.Row.Tag as int?;
            if (dbRow == null)
                return;
            client.RemoveRow(new() { DbName=dbName, TableId=TableInfo.Id, RowId=dbRow.Value });
            if (Parent.FindForm() is FormDatabase parentForm)
                parentForm.RefreshDifferences(TableInfo.Id);
        }

        private void FormTable_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Parent.FindForm() is FormDatabase parentForm)
                parentForm.ListTables(TableInfo.Id);
        }
    }
}
