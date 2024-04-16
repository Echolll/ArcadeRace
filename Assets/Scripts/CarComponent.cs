using UnityEngine;

namespace CarRacing
{
    [RequireComponent(typeof(Rigidbody),typeof(WheelComponent),typeof(BaseInputController))]
    public class CarComponent : MonoBehaviour
    {
        private WheelComponent _wheels;
        private BaseInputController _input;
        private Rigidbody _rigidbody;

        [SerializeField,Range(5f,45f)]
        private float _maxSteerAngle = 25f;
        [SerializeField]
        private float _torque = 2500f;
        [SerializeField, Range(0,float.MaxValue)]
        private float _handBrakeTorque = float.MaxValue;
        [SerializeField]
        private Vector3 _centerOfMass;

        private void Start()
        {
            _wheels = GetComponent<WheelComponent>();
            _input = GetComponent<BaseInputController>();
            _rigidbody = GetComponent<Rigidbody>();
            
            _rigidbody.centerOfMass = _centerOfMass;
            
            _input.OnHandBrakeEvent += OnHandBrake;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.TransformPoint(_centerOfMass), 0.25f);
        }

        private void OnHandBrake(bool value)
        {
            if(value)
            {
                foreach(var wheel in _wheels.GetRearWeels)
                {
                    wheel.brakeTorque = _handBrakeTorque;
                    wheel.motorTorque = 0f;
                }
            }
            else
            {
                foreach (var wheel in _wheels.GetRearWeels)
                {
                    wheel.brakeTorque = 0f;
                }
            }
        }

        private void FixedUpdate()
        {
            _wheels.UpdateVisual(_input.Rotate * _maxSteerAngle);
            var torque = _input.Acceleration * _torque / 2f;
            foreach (var wheel in _wheels.GetFrontWheels)
            {
              wheel.motorTorque = torque;
            }
        }

        private void OnDestroy()
        {
            _input.OnHandBrakeEvent -= OnHandBrake;
        }

    }
}
