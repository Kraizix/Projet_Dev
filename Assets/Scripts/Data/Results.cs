using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Results
{
    public float Score;
    public string Level;
    public int TimePlayed;

    public Results(float score, string level, int timePlayed)
    {
        Score = score;
        Level = level;
        TimePlayed = timePlayed;
    }
}
