using UnityEngine;

namespace CarRacing
{
    public class AfterFinishComponent : MonoBehaviour
    {
        [SerializeField]
        private LeaderboardComponent _leaderPanel;
        [SerializeField]
        private YourNameComponent _namePanel;

        private float _timer;

        public void OpenNameWindowAfterFinish(float value)
        {
            _timer = value;
            _namePanel.gameObject.SetActive(true);
        }

        public void OpenLeaderboard(string name)
        {
            _leaderPanel.CurrectPlayerRecord(name, _timer);
            _leaderPanel.gameObject.SetActive(true);
        }
    }
}
