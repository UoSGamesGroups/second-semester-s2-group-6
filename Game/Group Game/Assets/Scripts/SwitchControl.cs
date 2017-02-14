﻿using UnityEngine;
using System.Collections;

public class SwitchControl : MonoBehaviour {

    public DoorControl MyDoor;
    //MyDoor.active;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="player"|| collision.gameObject.tag == "Object")
        {
            MyDoor.Active = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player" || collision.gameObject.tag == "Object")
        {
            MyDoor.Active = true;
        }
    }
}