using UnityEngine;


namespace CarRacing
{
    public class PlayerInputController : BaseInputController
    {
        private CarControls _controls;

        protected override void FixedUpdate()
        {
            var direction = _controls.Car.Rotate.ReadValue<float>();
            if(direction == 0 && Rotate != 0f)
            {
                Rotate = Rotate > 0f
                    ? Rotate - Time.fixedDeltaTime
                    : Rotate + Time.fixedDeltaTime;
            }
            else
            {
                Rotate = Mathf.Clamp(Rotate + direction + Time.fixedDeltaTime, -1f, 1f);
            }

            Acceleration = _controls.Car.Acceleration.ReadValue<float>();
        }

        private void Awake()
        {
            _controls = new CarControls();
            _controls.Car.HandBrake.performed += _ => CallHandBrake(true);
            _controls.Car.HandBrake.canceled += _ => CallHandBrake(false);
        }
        
        private void OnEnable() => _controls.Car.Enable();

        private void OnDisable() => _controls.Car.Disable();
     
        private void OnDestroy() => _controls.Dispose();
  
    }
}
