using System;
using System.Collections.Generic;
using UnityEngine;

namespace SO.Scripts.Signal
{
    [CreateAssetMenu(menuName = "SO/Scripts/Signal/SignalBus", fileName = "SignalBus.asset")]
    public class SignalBus : ScriptableObject
    {
        private Dictionary<BindingId, SignalDeclaration> _declarationMap = new();
        private Dictionary<SignalSubscriptionId, SignalSubscription> _subscriptionMap = new();

        public void DeclareSignal<TSignal>()
        {
            DeclareSignal(typeof(TSignal));
        }

        public void DeclareSignal(Type signalType)
        {
            var signalId = new BindingId(signalType, null);
            if (!_declarationMap.ContainsKey(signalId))
            {
                _declarationMap.Add(signalId, new SignalDeclaration());
            }
        }

        public void Subscribe<TSignal>(Action<object> callback)
        {
            Action<object> wrapperCallback = args => callback((TSignal)args);
            var signalId = new BindingId(typeof(TSignal), null);
            var declaration = GetDeclaration(signalId);
            if (declaration != null)
            {
                SignalSubscription subscription = new SignalSubscription(wrapperCallback, declaration);
            }
        }

        public void UnSubscribe<T>(Action<object> callback)
        {
        }

        private SignalDeclaration GetDeclaration(BindingId id)
        {
            SignalDeclaration declaration;
            if (_declarationMap.TryGetValue(id, out declaration))
            {
                return declaration;
            }

            return null;
        }
    }
}