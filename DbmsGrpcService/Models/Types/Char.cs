namespace DBMS.Models.Types
{
    public class Char : Type
    {
        public const byte CODE = 3;

        public override Values.Char Parse(string s)
        {
            return new Values.Char(this, s);
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(CODE);
        }

        public override Values.Char ReadValue(BinaryReader reader) => new(reader, this);

        public override bool Equals(object? obj) => obj is Char;

        public override string ToString() => "Char";

        public override DbmsGrpc.Messages.Types.Type ToMessage() =>
            new()
            {
                Char = new()
            };
    }
}
