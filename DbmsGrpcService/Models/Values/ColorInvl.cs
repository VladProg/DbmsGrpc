using System.Text.RegularExpressions;

namespace DBMS.Models.Values
{
    public class ColorInvl : Value
    {
        public readonly byte R, G, B;

        public new Types.ColorInvl Type => (base.Type as Types.ColorInvl)!;

        private void ValidateRange(string name, byte val, byte min, byte max)
        {
            if (val < min || val > max)
                throw new ArgumentOutOfRangeException($"{name} = {val} but allowed range is [{min}..{max}]", (Exception?)null);
        }

        private byte ParseByte(string name, string str, byte min, byte max)
        {
            try
            {
                byte val = byte.Parse(str);
                ValidateRange(name, val, min, max);
                return val;
            }
            catch
            {
                throw new ArgumentOutOfRangeException($"{name} = {str} but allowed range is [{min}..{max}]", (Exception?)null);
            }
        }

        private void Validate()
        {
            ValidateRange("R", R, Type.R1, Type.R2);
            ValidateRange("G", G, Type.G1, Type.G2);
            ValidateRange("B", B, Type.B1, Type.B2);
        }

        public ColorInvl(Types.ColorInvl type, byte r, byte g, byte b) : base(type)
        {
            R = r;
            G = g;
            B = b;
            Validate();
        }

        public ColorInvl(Types.ColorInvl type, string s) : base(type)
        {
            var numbers = Regex.Split(s, @"\D+").Where(n => !string.IsNullOrWhiteSpace(n)).ToArray();
            if (numbers.Length != 3)
                throw new FormatException("RGB-color should contain exactly 3 numbers");
            R = ParseByte("R", numbers[0], Type.R1, Type.R2);
            G = ParseByte("G", numbers[1], Type.G1, Type.G2);
            B = ParseByte("B", numbers[2], Type.B1, Type.B2);
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(R);
            writer.Write(G);
            writer.Write(B);
        }

        public ColorInvl(BinaryReader reader, Types.ColorInvl type)
            : this(type, reader.ReadByte(), reader.ReadByte(), reader.ReadByte()) { }

        public override string ToString() => $"(R={R}, G={G}, B={B})";

        public override bool Equals(object? obj) =>
            base.Equals(obj) && obj is ColorInvl other &&
            R == other.R && G == other.G && B == other.B;
    }
}
