using System;
using UnityEngine;
using UnityEngine.Events;

namespace Handlers
{
    public class TriggerHandler : MonoBehaviour
    {
        [SerializeField] private UnityEvent onTriggerEnter;
        
        public event UnityAction OnEnter
        {
            add => onTriggerEnter.AddListener(value);
            remove => onTriggerEnter.RemoveListener(value);
        } 

        private void OnTriggerEnter(Collider other)
        {
            onTriggerEnter?.Invoke();
        }
    }
}
