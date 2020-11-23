namespace Interview.BusinessLogic.Common
{
    public abstract class Entity
    {
        public long Id { get; protected set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Entity other)) return false;

            if (ReferenceEquals(this, other)) return true;

            if (GetType() != other.GetType()) return false;

            if (Id.Equals(default(long)) || other.Id.Equals(default(long))) return false;

            return Id.Equals(other.Id);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null) return true;

            if (a is null || b is null) return false;

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b) => !(a == b);

        public override int GetHashCode() => (GetType().ToString() + Id).GetHashCode();
    }
}
