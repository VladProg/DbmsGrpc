namespace DBMS.Models.Types
{
    public abstract class Type
    {
        public abstract Values.Value Parse(string s);
        public abstract void Write(BinaryWriter writer);

        public static Type Read(BinaryReader reader)
        {
            return reader.ReadByte() switch
            {
                Integer.CODE => new Integer(),
                Real.CODE => new Real(),
                Char.CODE => new Char(),
                String.CODE => new String(),
                Color.CODE => new Color(),
                ColorInvl.CODE => new ColorInvl(reader),
                _ => throw new NotImplementedException("Unknown type code")
            };
        }

        public abstract Values.Value ReadValue(BinaryReader reader);

        public static bool operator ==(Type left, Type right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Type left, Type right)
        {
            return !left.Equals(right);
        }

        public abstract DbmsGrpc.Messages.Types.Type ToMessage();

        public static Type FromMessage(DbmsGrpc.Messages.Types.Type message)
        {
            return message.InstanceCase switch
            {
                DbmsGrpc.Messages.Types.Type.InstanceOneofCase.Char => new Types.Char(),
                DbmsGrpc.Messages.Types.Type.InstanceOneofCase.Color => new Types.Color(),
                DbmsGrpc.Messages.Types.Type.InstanceOneofCase.ColorInvl => new Types.ColorInvl(
                    (byte)message.ColorInvl.R1,
                    (byte)message.ColorInvl.R2,
                    (byte)message.ColorInvl.G1,
                    (byte)message.ColorInvl.G2,
                    (byte)message.ColorInvl.B1,
                    (byte)message.ColorInvl.B2),
                DbmsGrpc.Messages.Types.Type.InstanceOneofCase.Integer => new Types.Integer(),
                DbmsGrpc.Messages.Types.Type.InstanceOneofCase.Real => new Types.Real(),
                DbmsGrpc.Messages.Types.Type.InstanceOneofCase.String => new Types.String(),
            };
        }
    }
}
