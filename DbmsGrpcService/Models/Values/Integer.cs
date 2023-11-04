using System.Numerics;

namespace DBMS.Models.Values
{
    public class Integer : Value
    {
        public readonly BigInteger Val;

        public Integer(Types.Integer type, BigInteger val) : base(type)
        {
            Val = val;
        }

        public Integer(Types.Integer type, string s) : base(type)
        {
            try
            {
                Val = BigInteger.Parse(s);
            }
            catch
            {
                throw new FormatException("Incorrect value for type Integer");
            }
        }

        public override void Write(BinaryWriter writer)
        {
            byte[] bytes = Val.ToByteArray();
            writer.Write7BitEncodedInt(bytes.Length);
            writer.Write(bytes);
        }

        public Integer(BinaryReader reader, Types.Integer type) : base(type)
        {
            int byteCount = reader.Read7BitEncodedInt();
            byte[] bytes = reader.ReadBytes(byteCount);
            Val = new BigInteger(bytes);
        }

        public override string ToString() => Val.ToString();

        public override bool Equals(object? obj)
            => base.Equals(obj) && obj is Integer other && Val == other.Val;
    }
}
