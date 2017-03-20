using UnityEngine;
using System.Collections;

public class SwitchControl : MonoBehaviour {

    public DoorControl MyDoor;
    //MyDoor.active;
    // Use this for initialization
    bool WeightAttached = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            MyDoor.Active = false;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle") {
            if (!WeightAttached) {
                WeightAttached = true;
                SwitchWeightStickControl Ball = collision.gameObject.GetComponent<SwitchWeightStickControl>();
                Ball.Stuck = true;
                Ball.PlatePos = transform.position;
                
            }
            if(MyDoor.Active!=true)
                MyDoor.Active = true;
        }

        else if (collision.gameObject.tag == "Player") {
            MyDoor.Active = true;
        }
    }
}
