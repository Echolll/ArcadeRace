using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace CarRacing
{
    public class LeaderboardComponent : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _timer;
        [SerializeField]
        private TMP_Text _name;

        [SerializeField]
        private List<TMP_Text> _leaderboard;

        [SerializeField]
        LeaderboardMangerComponent _leaderboardManger;

        public void CurrectPlayerRecord(string name, float timer)
        {
            _timer.text = "Time:" + FloatNumberToTimer(timer);
            _name.text = "Name:" + name.ToString();     
            _leaderboardManger.AddPlayerRecord(name, timer);
        }

        public void OnClick_ExitGame()
        {
            EditorApplication.isPlaying = false;
        }

        public void UpdateLeaderboard(List<PlayerRecord> records)
        {
            for (int i = 0; i < _leaderboard.Count; i++)
            {
                if (i < records.Count)
                {
                    _leaderboard[i].text = $"{i + 1}. Name: {records[i].name} Timer: {FloatNumberToTimer(records[i].timer)}";
                }
                else
                {
                    _leaderboard[i].text = $"{i + 1}. Name: ----- Timer: --:--:--";
                }
            }
        }

        private string FloatNumberToTimer(float value)
        {
            int minutes = (int)(value / 60);
            int seconds = (int)(value % 60);
            int milliseconds = (int)((value - Mathf.Floor(value)) * 10);

            string timerString = string.Format("{0:00}:{1:00}:{2}", minutes, seconds, milliseconds);

            return timerString;
        }
    }
}
