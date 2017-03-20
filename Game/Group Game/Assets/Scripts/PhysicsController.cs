//File Details
//Name:        Daniel Beales
//Student ID:  S185384
//Created:     21/02/2017
//Last Edited: 21/02/2017
//Last Editor: Daniel Beales
//File:        PhysicsController.cs


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsController : MonoBehaviour {








    #region Physics Material varibles
    Rigidbody2D rb_;
    public float Friction;
    public float Bounciness;
    public float Weight;
    PolygonCollider2D thiscol;
    PhysicsMaterial2D PM;
    #endregion



    // Use this for initialization
    void Start () {
        //material stuff
        thiscol = this.GetComponent<PolygonCollider2D>();
        //create new physics material
        PM = new PhysicsMaterial2D();
        //give physics material properties
        PM.friction = Friction;
        PM.bounciness = Bounciness;
        //give collider this physics material
        thiscol.sharedMaterial = PM;
        //give wanteed weight
        rb_ = this.GetComponent<Rigidbody2D>();
        rb_.mass = Weight;
	}
	
}
