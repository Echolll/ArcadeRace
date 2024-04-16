using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

namespace CarRacing
{
    public class LeaderboardMangerComponent : MonoBehaviour
    {
        [SerializeField]
        private List<PlayerRecord> _leaderboardData;
        [SerializeField]
        private LeaderboardComponent _leaderboardComponent;

        private string _savePath;

        private void Start()
        {
            _savePath = Application.dataPath + "/leaderboardData.json";
            LoadLeaderboardData();
            UpdateLeaderboardUI();
        }

        public void AddPlayerRecord(string name, float timer)
        {
            PlayerRecord newRecord = new PlayerRecord(name, timer);
            _leaderboardData.Add(newRecord);
            SaveLeaderboardData();
            UpdateLeaderboardUI();
        }

        private void SaveLeaderboardData()
        {
            string jsonData = JsonUtility.ToJson(new LeaderboardData(_leaderboardData));
            File.WriteAllText(_savePath, jsonData);
        }

        private void UpdateLeaderboardUI()
        {
            SortLeaderboardByTimerAscending();
            _leaderboardComponent.UpdateLeaderboard(_leaderboardData);
        }

        public void SortLeaderboardByTimerAscending()
        {
            _leaderboardData = _leaderboardData.OrderBy(record => record.timer).ToList();
            SaveLeaderboardData();
        }

        private void LoadLeaderboardData()
        {
            if(File.Exists(_savePath))
            {
               string jsonData = File.ReadAllText(_savePath);
               LeaderboardData data = JsonUtility.FromJson<LeaderboardData>(jsonData);
               _leaderboardData = data.records;
            }
            else
            {
                _leaderboardData = new List<PlayerRecord>();
            }
        }
    }
}
