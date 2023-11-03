namespace DBMS.Models.Types
{
    public class ColorInvl : Type
    {
        public const byte CODE = 6;

        public readonly byte R1, R2, G1, G2, B1, B2;

        private void Validate()
        {
            if (R1 > R2)
                throw new ArgumentException("Minimum bound of R must be less than or equal to maximum bound of R");
            if (G1 > G2)
                throw new ArgumentException("Minimum bound of G must be less than or equal to maximum bound of G");
            if (B1 > B2)
                throw new ArgumentException("Minimum bound of B must be less than or equal to maximum bound of B");
        }

        public ColorInvl(byte r1, byte r2, byte g1, byte g2, byte b1, byte b2)
        {
            R1 = r1;
            R2 = r2;
            G1 = g1;
            G2 = g2;
            B1 = b1;
            B2 = b2;
            Validate();
        }

        public override Values.ColorInvl Parse(string s)
        {
            return new Values.ColorInvl(this, s);
        }

        public override void Write(BinaryWriter writer)
        {
            writer.Write(CODE);
            writer.Write(R1);
            writer.Write(R2);
            writer.Write(G1);
            writer.Write(G2);
            writer.Write(B1);
            writer.Write(B2);
        }

        public ColorInvl(BinaryReader reader)
        {
            R1 = reader.ReadByte();
            R2 = reader.ReadByte();
            G1 = reader.ReadByte();
            G2 = reader.ReadByte();
            B1 = reader.ReadByte();
            B2 = reader.ReadByte();
            Validate();
        }

        public override Values.ColorInvl ReadValue(BinaryReader reader) => new(reader, this);

        public override bool Equals(object? obj) =>
            obj is ColorInvl other &&
            R1 == other.R1 && R2 == other.R2 &&
            G1 == other.G1 && G2 == other.G2 &&
            B1 == other.B1 && B2 == other.B2;

        public override string ToString() => $"ColorInvl (R∈[{R1}..{R2}], G∈[{G1}..{G2}], B∈[{B1}..{B2}])";

        public override DbmsGrpc.Messages.Types.Type ToMessage() =>
            new()
            {
                ColorInvl = new() { R1 = R1, R2 = R2, G1 = G1, G2 = G2, B1 = B1, B2 = B2 }
            };
    }
}
