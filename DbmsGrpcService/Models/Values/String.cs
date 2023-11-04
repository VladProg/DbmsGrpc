using System.Numerics;

namespace DBMS.Models.Values
{
    public class String : Value
    {
        public readonly string Val;

        public String(Types.String type, string val) : base(type)
        {
            Val = val;
        }

        public override void Write(BinaryWriter writer) => writer.Write(Val);

        public String(BinaryReader reader, Types.String type) : this(type, reader.ReadString()) { }

        public override string ToString() => Val;

        public override bool Equals(object? obj)
            => base.Equals(obj) && obj is String other && Val == other.Val;
    }
}
