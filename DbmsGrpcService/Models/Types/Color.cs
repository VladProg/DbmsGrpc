namespace DBMS.Models.Types
{
    public class Color : Type
    {
        public const byte CODE = 5;

        public override Values.Color Parse(string s)
        {
            return new Values.Color(this, s);
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(CODE);
        }

        public override Values.Color ReadValue(BinaryReader reader) => new(reader, this);

        public override bool Equals(object? obj) => obj is Color;

        public override string ToString() => "Color";

        public override DbmsGrpc.Messages.Types.Type ToMessage() =>
            new()
            {
                Color = new(),
                ToStr = ToString()
            };
    }
}
