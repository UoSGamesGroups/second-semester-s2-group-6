using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {


    public int DoorMethod;
    public bool Active = false;
    Vector3 StartPos;
    float StartRotation;
    float Angle;
    public GameObject Corner;
    public int Multiplier=1;

    /*
     
         1 is rotate from corner
         2 is move perpen long part
         2 is move paralell to long part
         
         
         */



    Rigidbody2D RB;
	// Use this for initialization
	void Start () {
        RB = GetComponent<Rigidbody2D>();
        StartPos = transform.position;
        StartRotation = transform.rotation.z;
        Angle = transform.rotation.z;
	}
	
	// Update is called once per frame
	void Update () {
        switch (DoorMethod)
        {
            case 1:
                if (Active)
                {
                    if (transform.rotation.z != StartRotation + 90 * Multiplier)
                    {
                        transform.rotation = new Quaternion(0, 0, transform.rotation.z+0.001f*Multiplier, 0);//put script on corner. attach door as child
                    }
                }
                else
                {
                    if (transform.rotation.z != StartRotation )
                    {
                        transform.rotation = new Quaternion(0, 0, transform.rotation.z - 0.001f * Multiplier, 0);//put script on corner. attach door as child
                    }
                }
            break;

            case 2:
                if (Active) {
                    if (Magnitude(new Vector2(transform.position.x - StartPos.x, transform.position.y - StartPos.y)) < 5) {
                        transform.position = new Vector3(transform.position.x + Mathf.Sin(transform.rotation.z), transform.position.y + Mathf.Cos(transform.rotation.z), transform.position.z);
                    }
                }
                else
                {
                    if(Magnitude(new Vector2(transform.position.x - StartPos.x, transform.position.y - StartPos.y)) > 0.1f)
                    {
                        transform.position = new Vector3(transform.position.x - Mathf.Sin(transform.rotation.z), transform.position.y - Mathf.Cos(transform.rotation.z), transform.position.z);
                    }
                }
                    break;
            case 3:
                if (Active)
                {
                    if (Magnitude(new Vector2(transform.position.x - StartPos.x, transform.position.y - StartPos.y)) < 5)
                    {
                        transform.position = new Vector3(transform.position.x + Mathf.Cos(transform.rotation.z), transform.position.y + Mathf.Sin(transform.rotation.z), transform.position.z);
                    }
                }
                else
                {
                    if (Magnitude(new Vector2(transform.position.x - StartPos.x, transform.position.y - StartPos.y)) > 0.1f)
                    {
                        transform.position = new Vector3(transform.position.x - Mathf.Cos(transform.rotation.z), transform.position.y - Mathf.Sin(transform.rotation.z), transform.position.z);
                    }
                }



                break;



        }
	
	}


    float Magnitude(Vector3 input)
    {
        return Mathf.Sqrt(Mathf.Pow(input.x,2) + Mathf.Pow(input.y, 2));
    }
}
