using System;

namespace SO.Scripts.Signal
{
    public struct SignalSubscriptionId : IEquatable<SignalSubscriptionId>
    {
        private BindingId _signalId;
        private object _callback;

        public SignalSubscriptionId(BindingId signalId, object callback)
        {
            _signalId = signalId;
            _callback = callback;
        }

        public BindingId SignalId
        {
            get { return _signalId; }
        }

        public object Callback
        {
            get { return _callback; }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_signalId, _callback);
        }

        public bool Equals(SignalSubscriptionId other)
        {
            return Equals(_signalId, other._signalId)
                   && Equals(Callback, other.Callback);
        }

        public override bool Equals(object obj)
        {
            if (obj is SignalSubscriptionId)
            {
                return Equals((SignalSubscriptionId)obj);
            }

            return false;
        }

        public static bool operator ==(SignalSubscriptionId left, SignalSubscriptionId right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SignalSubscriptionId left, SignalSubscriptionId right)
        {
            return !left.Equals(right);
        }
    }
}