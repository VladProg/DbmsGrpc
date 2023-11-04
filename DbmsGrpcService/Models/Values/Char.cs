using System.Numerics;

namespace DBMS.Models.Values
{
    public class Char : Value
    {
        public readonly char Val;

        public Char(Types.Char type, char val) : base(type)
        {
            Val = val;
        }

        public Char(Types.Char type, string s) : base(type)
        {
            try
            {
                Val = char.Parse(s);
            }
            catch
            {
                throw new FormatException("Char must contain a single character");
            }
        }

        public override void Write(BinaryWriter writer) => writer.Write(Val);

        public Char(BinaryReader reader, Types.Char type) : this(type, reader.ReadChar()) { }

        public override string ToString() => Val.ToString();

        public override bool Equals(object? obj)
            => base.Equals(obj) && obj is Char other && Val == other.Val;
    }
}
