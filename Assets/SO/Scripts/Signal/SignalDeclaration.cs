using System.Collections.Generic;

namespace SO.Scripts.Signal
{
    public class SignalDeclaration
    {
        private BindingId _bindingId;
        private List<SignalSubscription> _subscriptions;


        public BindingId BindingId
        {
            get { return _bindingId; }
        }

        public void Add(SignalSubscription signalSubscription)
        {
            _subscriptions.Add(signalSubscription);
        }

        public void Remove(SignalSubscription signalSubscription)
        {
            _subscriptions.Remove(signalSubscription);
        }
    }
}