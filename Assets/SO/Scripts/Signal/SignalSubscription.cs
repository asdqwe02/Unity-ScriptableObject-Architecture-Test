using System;

namespace SO.Scripts.Signal
{
    public class SignalSubscription : IDisposable
    {
        private Action<object> _callback;
        SignalDeclaration _declaration;
        private BindingId _signalId;

        public BindingId SignalId
        {
            get { return _signalId; }
        }

        public SignalSubscription(Action<object> callback, SignalDeclaration declaration)
        {
            _callback = callback;
            _declaration = declaration;
            _signalId = declaration.BindingId;
            declaration.Add(this);
        }

        public void Dispose()
        {
            _callback = null;
            _signalId = new BindingId();
            if (_declaration != null)
            {
                _declaration.Remove(this);
            }
            _declaration = null;
        }
    }
}