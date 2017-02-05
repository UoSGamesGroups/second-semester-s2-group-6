using UnityEngine;
using System.Collections;

public class TimerScript : MonoBehaviour {
    CameraControl CamScript;

    public GUISkin theSkin;
    bool TimeBool = true;
    int TimesinceStart=0;
	// Use this for initialization
	void Start () {
        CamScript = GetComponent<CameraControl>();

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
        TimesinceStart++;
        TimeBool = true;
    }

    private void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width*0.48f, Screen.height*(8/9), 30, 40),TimesinceStart.ToString());
    }

}
