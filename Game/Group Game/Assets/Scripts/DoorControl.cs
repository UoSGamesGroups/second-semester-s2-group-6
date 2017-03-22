using UnityEngine;
using System.Collections;

public class DoorControl : MonoBehaviour {


    public int DoorMethod;
    public bool Active = false;
    Vector3 StartPos;
    float StartRotation;
    public int Multiplier=1;
    public int Side;
    public string Name ="";
    /*
     
         1 is rotate from corner
         2 is move perpen long part
         2 is move paralell to long part
         
         
         */


        
	// Use this for initialization
	void Start () {
        StartPos = transform.position;
        StartRotation = transform.rotation.z;
        if (transform.position.x > 0) {
            Side = -1;
        }
        else {
            Side = 1;
        }
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
                        transform.position = new Vector3(transform.position.x + Side * Mathf.Sin(Mathf.Deg2Rad * -transform.eulerAngles.z), transform.position.y + Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), transform.position.z);
                    }
                }
                else
                {
                    if(Magnitude(new Vector2(transform.position.x - StartPos.x, transform.position.y - StartPos.y)) > 0.1f)
                    {
                        transform.position = new Vector3(Side* transform.position.x - Mathf.Sin(Mathf.Deg2Rad * -transform.eulerAngles.z), transform.position.y - Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), transform.position.z);
                    }
                }
            break;

            case 3:
                if (Active)
                {
                    if (Magnitude(new Vector2(transform.position.x - StartPos.x, transform.position.y - StartPos.y)) < 5)
                    {
                        transform.position = new Vector3(transform.position.x + Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), transform.position.y + Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z), transform.position.z);
                    }
                }
                else
                {
                    if (Magnitude(new Vector2(transform.position.x - StartPos.x, transform.position.y - StartPos.y)) > 0.1f)
                    {
                        transform.position = new Vector3(transform.position.x - Mathf.Cos(Mathf.Deg2Rad * transform.eulerAngles.z), transform.position.y - Mathf.Sin(Mathf.Deg2Rad * transform.eulerAngles.z), transform.position.z);
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
