namespace DBMS.Models.Types
{
    public class Integer : Type
    {
        public const byte CODE = 1;

        public override Values.Integer Parse(string s)
        {
            return new Values.Integer(this, s);
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(CODE);
        }

        public override Values.Integer ReadValue(BinaryReader reader) => new(reader, this);

        public override bool Equals(object? obj) => obj is Integer;

        public override string ToString() => "Integer";

        public override DbmsGrpc.Messages.Types.Type ToMessage() =>
            new()
            {
                Integer = new(),
                ToStr = ToString()
            };
    }
}
