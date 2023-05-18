using System;
using Handlers;
using UnityEngine;

namespace Traps
{
    public class Trap : MonoBehaviour
    {
        [SerializeField] private TriggerHandler triggerHandler;

        private void Start()
        {
            triggerHandler.OnEnter += () =>
            {
                GameManager.Instance.Lose();
            };
        }
    }
}