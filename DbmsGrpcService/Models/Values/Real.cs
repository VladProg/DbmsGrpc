using System.CodeDom;
using System.Globalization;

namespace DBMS.Models.Values
{
    public class Real : Value
    {
        public readonly decimal Val;

        public Real(Types.Real type, decimal val) : base(type)
        {
            Val = val;
        }

        public Real(Types.Real type, string s)
            : base(type)
        {
            try
            {
                Val = decimal.Parse(s.Replace(",", "."), CultureInfo.InvariantCulture);
            }
            catch
            {
                throw new FormatException("Incorrect value for type Real");
            }
        }

        public override void Write(BinaryWriter writer) => writer.Write(Val);

        public Real(BinaryReader reader, Types.Real type) : this(type, reader.ReadDecimal()) { }

        public override string ToString() => Val.ToString().Replace(".", ",");

        public override bool Equals(object? obj)
            => base.Equals(obj) && obj is Real other && Val == other.Val;
    }
}
