using System;
using UnityEngine;


namespace CarRacing
{
    public abstract class BaseInputController : MonoBehaviour
    {
        public float Acceleration { get; protected set; }
        
        public float Rotate { get; protected set; }

        public event Action<bool> OnHandBrakeEvent;

        protected abstract void FixedUpdate();

        protected void CallHandBrake(bool value) => OnHandBrakeEvent?.Invoke(value);
    }
}
