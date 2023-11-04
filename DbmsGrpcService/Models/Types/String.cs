namespace DBMS.Models.Types
{
    public class String : Type
    {
        public const byte CODE = 4;

        public override Values.String Parse(string s)
        {
            return new Values.String(this, s);
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(CODE);
        }

        public override Values.String ReadValue(BinaryReader reader) => new(reader, this);

        public override bool Equals(object? obj) => obj is String;

        public override string ToString() => "String";

        public override DbmsGrpc.Messages.Types.Type ToMessage() =>
            new()
            {
                String = new(),
                ToStr = ToString()
            };
    }
}
