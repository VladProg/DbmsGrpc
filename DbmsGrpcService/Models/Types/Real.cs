namespace DBMS.Models.Types
{
    public class Real : Type
    {
        public const byte CODE = 2;

        public override Values.Real Parse(string s)
        {
            return new Values.Real(this, s);
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(CODE);
        }

        public override Values.Real ReadValue(BinaryReader reader) => new(reader, this);

        public override bool Equals(object? obj) => obj is Real;

        public override string ToString() => "Real";

        public override DbmsGrpc.Messages.Types.Type ToMessage() =>
            new()
            {
                Real = new(),
                ToStr = ToString()
            };
    }
}
