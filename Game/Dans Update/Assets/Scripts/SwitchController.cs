//File Details
//Name:        Daniel Beales
//Student ID:  S185384
//Created:     06/02/2017
//Last Edited: 06/02/2017
//File:        SwitchController.cs

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : MonoBehaviour {

    #region GameObjects
    public GameObject Door; //Main door object.
    public GameObject Corner; //Empty Game objects that are attached.
    #endregion

    #region Vectors
    public Vector3 CornerCords;
    #endregion

    private float cornerPositionz; //Empty Game Object Cords
    private float cornerPostionY; //Empty Game Object Cords
    private float cornerPositonX; //Empty Game Object Cords
    [Range(0.1f, 5f)]
    public float rotationspeed = 0.5f; //How fast we want to rotate.
    
    #region KeyCodes
    public KeyCode Option1;
    public KeyCode Option2;
    public KeyCode Option3;
    public KeyCode Option4;
    public KeyCode Option5;
    #endregion

    //Maybe
    [Range(0.1f, 5f)]
    public float QuaterionRotationSmoothing = 0.1f;
    private Quaternion targetRotation;
    private Quaternion startingPos;

    //Option4
    bool hasDoorOpened = false;
    float DoorStartingPosX;
    float DoorCurrentPosX;    
    float FinishDoorPosX;
    [Range(1f, 25f)]
    public float FinishDoorPosXInt;




    // Use this for initialization
    void Start () {

        //Make sure we know where the door is at the start of the script.
		DoorStartingPosX = Door.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(Option1))
        {
            //V2        
            targetRotation = Quaternion.LookRotation(transform.forward, Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, QuaterionRotationSmoothing * Time.deltaTime);
        }
        else if (Input.GetKey(Option2))
        {
            //Using Rotate around, Collects the x,y,z position manually and inputs them as the position to rotate from.
            cornerPositonX = Corner.transform.position.x;
            cornerPostionY = Corner.transform.position.y;
            cornerPositionz = Corner.transform.position.z;

            CornerCords.Set(cornerPositonX, cornerPostionY, cornerPositionz);
            Door.transform.RotateAround(CornerCords, Vector3.forward, 90f * Time.deltaTime * rotationspeed);


        }else if (Input.GetKey(Option3))
        {
            //This is all guess work and google work.
            targetRotation = Quaternion.Euler(0, 0, 90);
            startingPos = this.transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smooth * Time.deltaTime);

        }
        else if (Input.GetKey(Option4))
        {            
            //>>>>>>>>>>>>>>We will want this To be a collision rather than a trigger with Keys.<<<<<<<<<<<<<<<<<


            //How much we want the difference between where the door is, to where we want it to be.
            FinishDoorPosX = DoorStartingPosX + FinishDoorPosXInt;

            //Has the door already been opened
            if (hasDoorOpened == false)
            {
                //While Where the door current is on the X Axis is Less or equal than where we want it to be, Carry on rollling through with a translate each time.
                while (DoorCurrentPosX <= FinishDoorPosX)
                {
                    float translate = 0.01f;
                    
                    Door.transform.Translate(translate, 0, 0 * Time.deltaTime / 200);
                    DoorCurrentPosX = Door.transform.position.x;//Collect the current position for later use.

                }
                hasDoorOpened = true; //The door has now been opened.
            }            
            
        } else if (Input.GetKey(Option5))
        {
            //Option 5
        }



        #region OLD CODE
        //Door.transform.Translate(1,0,0 * (smooth * Time.deltaTime /1000));
        //Door.transform.Translate(transform.position + transform.up * (Time.deltaTime / 20));
        //Creates a variable to check the objects position.        
        // GameObject.Find("").transform.position;

        // transform.RotateAround(Vector3.zero,Vector3.right, 20 * Time.deltaTime);
        #endregion
    }
}
