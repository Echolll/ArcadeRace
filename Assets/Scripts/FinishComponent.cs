using UnityEngine;

namespace CarRacing
{
    public class FinishComponent : MonoBehaviour
    {
        [SerializeField]
        private TimerComponent _timer;
        [SerializeField]
        private AfterFinishComponent _afterFinish;

        private void OnTriggerEnter(Collider other)
        {
           if(other.TryGetComponent(out CarComponent car))
           {
                _timer.StopTimer();
                _afterFinish.OpenNameWindowAfterFinish(_timer.CurrectTime);
                Time.timeScale = 0f;
           }
        }
    }
}
