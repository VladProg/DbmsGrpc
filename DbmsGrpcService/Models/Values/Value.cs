namespace DBMS.Models.Values
{
    public abstract class Value
    {
        public Types.Type Type { get; init; }

        public Value(Types.Type type)
        {
            Type = type;
        }

        public abstract void Write(BinaryWriter writer);

        public override bool Equals(object? obj)
            => obj is Value other && Type.Equals(other.Type);
    }
}
