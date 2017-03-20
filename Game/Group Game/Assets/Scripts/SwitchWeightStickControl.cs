using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWeightStickControl : MonoBehaviour {

    public bool Stuck = false;
    public bool OnPlate = false;
    public Vector3 PlatePos;
    Rigidbody2D RB;
	// Use this for initialization
	
	// Update is called once per frame

    void Start() {
        RB = this.GetComponent<Rigidbody2D>();
    }
    float GetMag(Vector2 Diff) {
        return Mathf.Sqrt(Mathf.Pow(Diff.x, 2) + Mathf.Pow(Diff.y, 2));
    }



	void Update () {

		if(Stuck) {
            if(!OnPlate) {
                Vector2 Diff = new Vector2(PlatePos.x - this.transform.position.x, PlatePos.y - this.transform.position.y);
                if (GetMag(Diff)<1) {
                    OnPlate = true;
                    transform.position = PlatePos;
                }

                else { 
                    transform.position = new Vector2(transform.position.x+Diff.x/GetMag(Diff),transform.position.y + Diff.y/GetMag(Diff));
                }
             }
            RB.gravityScale = 0;
            RB.velocity = new Vector2(0, 0);
            transform.position = PlatePos;
        }
	}
}
