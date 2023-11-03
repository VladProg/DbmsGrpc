namespace DBMS.Models
{
    public class Column
    {
        public readonly string Name;
        public readonly Types.Type Type;

        public Column(string name, Types.Type type)
        {
            Name = name;
            Type = type;
        }

        public void Write(BinaryWriter writer)
        {
            writer.Write(Name);
            Type.Write(writer);
        }

        public Column(BinaryReader reader)
        {
            Name = reader.ReadString();
            Type = Types.Type.Read(reader);
        }

        public DbmsGrpc.Messages.Column ToMessage() =>
            new()
            {
                Name = Name,
                Type = Type.ToMessage()
            };
    }
}
