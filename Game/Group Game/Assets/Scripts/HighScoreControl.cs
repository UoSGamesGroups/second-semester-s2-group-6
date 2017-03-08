using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreControl : MonoBehaviour {
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }
    public int[] HighScores = new int[5];

    private void Start()
    {
        if (HighScores[0] == 0)
        {
            for(int i=0; i<HighScores.Length; i++)
            {
                HighScores[i] = 600;
            }
        }
    }

    public void checkTime(int Level, int Time)
    {
        if(HighScores[Level] > Time)
        {
            HighScores[Level] = Time;
        }
    }
}
