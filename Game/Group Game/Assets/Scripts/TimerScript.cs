using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {

    public GUISkin theSkin;
    public bool TimeBool = true;
    public int TimeSinceStart=0;
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (TimeBool)
        {
            TimeBool = false;
            StartCoroutine(Timer());
        }
	}

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1);
        TimeSinceStart++;
        TimeBool = true;
    }

    private void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width*0.50f, Screen.height*(8/9), 30, 40),TimeSinceStart.ToString());
    }

}
