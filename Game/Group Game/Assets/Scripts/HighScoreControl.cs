using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreControl : MonoBehaviour {
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public      int[] HighScores = { 600, 600, 600, 600, 600 };

    public void checkTime(int Level, int Time)
    {
        if(HighScores[Level] > Time)
        {
            HighScores[Level] = Time;
        }
    }
}
