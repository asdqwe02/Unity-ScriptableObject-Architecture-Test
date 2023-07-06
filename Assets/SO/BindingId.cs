using System;

namespace SO
{
    public struct BindingId : IEquatable<BindingId>
    {
        private Type _type;
        private object _identifier;

        public BindingId(Type type, object identifier)
        {
            _type = type;
            _identifier = identifier;
        }

        public Type Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public object Identifier
        {
            get { return _identifier; }
            set { _identifier = value; }
        }

        public bool Equals(BindingId other)
        {
            return this == other;
        }

        public override bool Equals(object obj)
        {
            if (obj is BindingId)
            {
                BindingId otherId = (BindingId)obj;
                return otherId == this;
            }

            return false;
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                // 17 and 29 are just arbitrary prime number to evenly distribute hashcode 
                int hash = 17;
                hash = hash * 29 + _type.GetHashCode();
                hash = hash * 29 + (_identifier == null ? 0 : _identifier.GetHashCode());
                return hash;
            }
        }

        public static bool operator ==(BindingId left, BindingId right)
        {
            return left.Type == right.Type && Equals(left.Identifier, right.Identifier);
        }

        public static bool operator !=(BindingId left, BindingId right)
        {
            return !left.Equals(right);
        }
    }
}