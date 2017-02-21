using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelDoorControl : MonoBehaviour {
    TimerScript Timer;
    HighScoreControl Scores;
    public PlayerControl[] Players;
    // Use this for initialization
    void Start () {
        Players = FindObjectsOfType<PlayerControl>();
        Timer  =  FindObjectOfType<TimerScript>();
        Scores = FindObjectOfType<HighScoreControl>();
    }


    IEnumerator LoadMenu(){
        for(int i=0; i<2; i++){
            Players[i].enabled = false;
        }
        yield return new WaitForSeconds(3);
        Application.LoadLevel(0);
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player") {
            StartCoroutine(LoadMenu());
            Scene scene = SceneManager.GetActiveScene();
            Timer.TimeBool = false;
            Scores.checkTime(scene.buildIndex-2, Timer.TimeSinceStart);
            
        }

    }
}
