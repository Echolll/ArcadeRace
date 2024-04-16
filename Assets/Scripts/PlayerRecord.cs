using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerRecord
{
    public string name;
    public float timer;

    public PlayerRecord(string name, float timer)
    {
        this.name = name;
        this.timer = timer;
    }
}
