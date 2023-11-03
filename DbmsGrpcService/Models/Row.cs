using System.Xml.Linq;

namespace DBMS.Models
{
    public class Row
    {
        public readonly int Id;
        public readonly Values.Value[] Cells;

        public Row(int id, Values.Value[] cells)
        {
            Id = id;
            Cells = cells;
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write7BitEncodedInt(Id);
            foreach (Values.Value cell in Cells)
                cell.Write(writer);
        }

        public Row(BinaryReader reader, Column[] columns)
        {
            Id = reader.Read7BitEncodedInt();
            Cells = new Values.Value[columns.Length];
            for (int i = 0; i < columns.Length; i++)
                Cells[i] = columns[i].Type.ReadValue(reader);
        }

        public override bool Equals(object? obj) => obj is Row other && Cells.SequenceEqual(other.Cells);

        public DbmsGrpc.Messages.Row ToMessage()
        {
            DbmsGrpc.Messages.Row message = new()
            {
                Id = Id
            };
            message.Cells.AddRange(from cell in Cells select cell.ToMessage());
            return message;
        }
    }
}
