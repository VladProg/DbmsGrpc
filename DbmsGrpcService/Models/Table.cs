using Grpc.Core;
using System.Collections.ObjectModel;

namespace DBMS.Models
{
    public class Table
    {
        public readonly int Id;
        public string Name;
        private readonly Column[] columns;
        private readonly SortedDictionary<int, Row> rows = new();
        private int nextId = 0;

        public ReadOnlyCollection<Column> Columns => Array.AsReadOnly(columns);
        public IReadOnlyDictionary<int, Row> Rows => rows;

        public Table(int id, string name, Column[] columns)
        {
            Id = id;
            Name = name;
            this.columns = (columns.Clone() as Column[])!;
        }

        public virtual Row AddRow(Values.Value[] cells)
        {
            if (cells.Length != columns.Length)
                throw new ArgumentException("Row length must be the same as number of columns");
            for (int i = 0; i < columns.Length; i++)
                if (cells[i].Type != columns[i].Type)
                    throw new ArgumentException("Cell type doesn't match corresponding column type");
            Row row = new(nextId, cells);
            rows[nextId] = row;
            nextId++;
            return row;
        }

        public virtual void RemoveRow(int id) => rows.Remove(id);

        public void Write(BinaryWriter writer)
        {
            writer.Write7BitEncodedInt(Id);
            writer.Write(Name);
            writer.Write7BitEncodedInt(columns.Length);
            foreach (Column column in columns)
                column.Write(writer);
            writer.Write7BitEncodedInt(rows.Count);
            foreach (KeyValuePair<int, Row> entry in rows)
                entry.Value.Write(writer);
            writer.Write7BitEncodedInt(nextId);
        }

        public Table(BinaryReader reader)
        {
            Id = reader.Read7BitEncodedInt();
            Name = reader.ReadString();
            int columnCount = reader.Read7BitEncodedInt();
            columns = new Column[columnCount];
            for (int i = 0; i < columnCount; i++)
                columns[i] = new(reader);
            int rowCount = reader.Read7BitEncodedInt();
            for (int i = 0; i < rowCount; i++)
            {
                Row row = new(reader, columns);
                rows[row.Id] = row;
            }
            nextId = reader.Read7BitEncodedInt();
        }

        public bool ContainsRow(Row row)
        {
            foreach (KeyValuePair<int, Row> entry in rows)
                if (row.Equals(entry.Value))
                    return true;
            return false;
        }

        public virtual void ClearRows() => rows.Clear();

        public virtual DbmsGrpc.Messages.TableInfo ToMessageInfo() =>
            new()
            {
                Id = Id,
                Name = Name
            };

        public virtual DbmsGrpc.Messages.Table ToMessage()
        {
            DbmsGrpc.Messages.Table message = new()
            {
                Id = Id,
                Name = Name
            };
            message.Columns.AddRange(from column in Columns select column.ToMessage());
            foreach (var entry in Rows)
                message.Rows.Add(entry.Key, entry.Value.ToMessage());
            return message;
        }
    }
}
