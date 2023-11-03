namespace DBMS.Models
{
    public class TableDifference : Table
    {
        public readonly Table LeftTable, RightTable;

        private TableDifference(int id, string name, Column[] columns, Table leftTable, Table rightTable)
            : base(id, name, columns)
        {
            LeftTable = leftTable;
            RightTable = rightTable;
        }

        public void Calculate()
        {
            base.ClearRows();
            foreach (Row row in LeftTable.Rows.Values)
                if (!RightTable.ContainsRow(row))
                    base.AddRow(row.Cells);
        }

        public static TableDifference Create(Table leftTable, Table rightTable)
        {
            if (leftTable.Columns.Count != rightTable.Columns.Count)
                throw new ArgumentException("Table difference: tables have different column counts");
            for (int i = 0; i < leftTable.Columns.Count; i++)
                if (leftTable.Columns[i].Type != rightTable.Columns[i].Type)
                    throw new ArgumentException("Table difference: tables have different column types");
            Column[] columns = new Column[leftTable.Columns.Count];
            for (int i = 0; i < leftTable.Columns.Count; i++)
                columns[i] = new(
                    leftTable.Columns[i].Name == rightTable.Columns[i].Name ?
                        leftTable.Columns[i].Name :
                        $"\"{leftTable.Columns[i].Name}\" / \"{rightTable.Columns[i].Name}\"",
                    leftTable.Columns[i].Type);
            TableDifference difference = new(
                leftTable.Id | (rightTable.Id << 16) | (1 << 31),
                $"Difference \"{leftTable.Name}\" - \"{rightTable.Name}\"",
                columns,
                leftTable, rightTable);
            return difference;
        }

        public static TableDifference CreateOrNull(Table leftTable, Table rightTable)
        {
            try
            {
                return Create(leftTable, rightTable);
            }
            catch
            {
                return null;
            }
        }

        public override Row AddRow(Values.Value[] cells) => throw new NotImplementedException("Table difference is read-only");
        public override void RemoveRow(int id) => throw new NotImplementedException("Table difference is read-only");
        public override void ClearRows() => throw new NotImplementedException("Table difference is read-only");

        public override DbmsGrpc.Messages.TableInfo ToMessageInfo()
        {
            var message = base.ToMessageInfo();
            message.TableDifferenceInfo = new()
            {
                LeftTableInfo = LeftTable.ToMessageInfo(),
                RightTableInfo = RightTable.ToMessageInfo()
            };
            return message;
        }

        public override DbmsGrpc.Messages.Table ToMessage()
        {
            var message = base.ToMessage();
            message.TableDifference = new();
            return message;
        }

        public static (int leftId, int rightId)? ParseId(int id)
        {
            if ((id & (1 << 31)) == 0)
                return null;
            id ^= 1 << 31;
            return (id & ((1 << 16) - 1), id >> 16);
        }
    }
}
