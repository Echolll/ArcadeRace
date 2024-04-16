using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LeaderboardData
{
    public List<PlayerRecord> records;

    public LeaderboardData(List<PlayerRecord> records)
    {
        this.records = records;
    }
}
