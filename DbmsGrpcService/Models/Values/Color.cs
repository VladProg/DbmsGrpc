using System.Text.RegularExpressions;

namespace DBMS.Models.Values
{
    public class Color : Value
    {
        public byte R, G, B;

        public Color(Types.Color type, byte r, byte g, byte b) : base(type)
        {
            R = r;
            G = g;
            B = b;
        }

        private byte ParseByte(string name, string str)
        {
            try
            {
                byte val = byte.Parse(str);
                return val;
            }
            catch
            {
                throw new ArgumentOutOfRangeException($"{name} = {str} but allowed range is [0..255]", (Exception?)null);
            }
        }

        public Color(Types.Color type, string s) : base(type)
        {
            var numbers = Regex.Split(s, @"\D+").Where(n => !string.IsNullOrWhiteSpace(n)).ToArray();
            if (numbers.Length != 3)
                throw new FormatException("RGB-color must contain exactly 3 numbers (R, G, B)");
            R = ParseByte("R", numbers[0]);
            G = ParseByte("G", numbers[1]);
            B = ParseByte("B", numbers[2]);
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(R);
            writer.Write(G);
            writer.Write(B);
        }

        public Color(BinaryReader reader, Types.Color type)
            : this(type, reader.ReadByte(), reader.ReadByte(), reader.ReadByte()) { }

        public override string ToString() => $"(R={R}, G={G}, B={B})";

        public override bool Equals(object? obj) =>
            base.Equals(obj) && obj is Color other &&
            R == other.R && G == other.G && B == other.B;
    }
}
