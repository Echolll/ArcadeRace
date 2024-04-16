using TMPro;
using UnityEngine;

namespace CarRacing
{
    public class TimerComponent : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _timerText;

        private float _currectTime = 0f;
        public float CurrectTime { get { return _currectTime; } }

        private bool _isTimerRunning = false;

        private void Update()
        {
            if (_isTimerRunning)
            {
                _currectTime += Time.deltaTime;
                UpdateTimerText();
            }
        }

        public void OnEnable() => _isTimerRunning = true;

        public void StopTimer() => _isTimerRunning = false;

        private void UpdateTimerText()
        {
            int minutes = (int)(_currectTime / 60);
            int seconds = (int)(_currectTime % 60);
            int milliseconds = (int)((_currectTime - Mathf.Floor(_currectTime)) * 10);

            string timerString = string.Format("{0:00}:{1:00}:{2}", minutes, seconds, milliseconds);
            _timerText.text = "Timer:" + timerString;
        }
    }
}
