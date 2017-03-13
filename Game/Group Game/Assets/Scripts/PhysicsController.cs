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



    public GameObject obj;
    public Rigidbody2D rb_;
    public PhysicsMaterial2D mat;
    public KeyCode V;
    
    #region Transforms
    public Transform originaldirection;
    public Transform relecteddirection;
    private Transform direction;
    #endregion
    
    #region Material Stuff
    //material stuff
    public float Friction;
    public float Bounciness;
    public float Weight;
    Material Mater;
    PolygonCollider2D thiscol;
    PhysicMaterial coll;
    #endregion

    #region Keycode 
    public KeyCode addWeight;
    public KeyCode doubleBounce;
    #endregion

    public PhysicsMaterial2D PM;
    public float TEST;

    // Use this for initialization
    void Start () {
        //material stuff
        thiscol = GetComponent<PolygonCollider2D>();
        PM = new PhysicsMaterial2D();
        PM.friction = Friction;
        PM.bounciness = Bounciness;
        thiscol.sharedMaterial = PM;
        rb_ = obj.GetComponent<Rigidbody2D>();
        rb_.mass = Weight;
        
	}
	
    void OnCollisionEnter(Collision collisionInfo)
    {
        //Here we want to when ever the object hits any sort of collider, we want it to bounce in the opposite direction, Tried using the addforce and reflect, could not get the direction bit working.

        Vector3 playerpos = this.transform.position;
        //relecteddirection.position = Vector3.Reflect(originaldirection.position, Vector3.right);
        
        //rb_.AddForce(Vector3.Reflect(direction, collisionInfo.contacts[0].normal * 5, ForceMode.Impulse));


    }
}
