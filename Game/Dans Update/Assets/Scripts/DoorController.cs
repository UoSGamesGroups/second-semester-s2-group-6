using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    public GameObject Door; //Main door object.


    float DoorStartingPosX;
    bool hasDoorOpened = false;
    float DoorCurrentPosX;
    float FinishDoorPosX;
    [Range(1f, 25f)]
    public float FinishDoorPosXInt;


    // Use this for initialization
    void Start () {
        //Make sure we know where the door is at the start of the script.
       DoorStartingPosX = Door.transform.position.x;
    }
	public SwitchController switchControl;
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Obstacle")
        {           
            ExitDoor();
        }
    }

    public void ExitDoor()
    {
       

    //1 - check if the door is already open
    //2 - check how we want to open the door

    //How much we want the difference between where the door is, to where we want it to be.
    FinishDoorPosX = DoorStartingPosX + FinishDoorPosXInt;

        String Rotation = "Upwards";
        //Has the door already been opened
        if (hasDoorOpened == false)
        {
            if (Rotation == ("Upwards"))
            {
                while (DoorCurrentPosX <= FinishDoorPosX)
                {
                    float translate = 0.01f;
                    Door.transform.Translate(translate, 0, 0 * Time.deltaTime / 200);
                    DoorCurrentPosX = Door.transform.position.x;//Collect the current position for later use.
                }
            }
            //While Where the door current is on the X Axis is Less or equal than where we want it to be, Carry on rollling through with a translate each time.
           
            hasDoorOpened = true; //The door has now been opened.
        }

    }   
    
}
