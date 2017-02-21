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
    
    #region Transforms
    public Transform originaldirection;
    public Transform relecteddirection;
    private Transform direction;
    #endregion
    
    #region Material Stuff
    //material stuff
    public float dynFriction;
    public float statFriction;
    public float bounciness;
    public float Weight;
    private Collider coll;
    #endregion
    
    #region Keycode 

    public KeyCode addWeight;
    public KeyCode doubleBounce;

    #endregion

    // Use this for initialization
    void Start () {
        //material stuff
        coll = obj.GetComponent<Collider>();
        coll.material.dynamicFriction = dynFriction;
        coll.material.staticFriction = statFriction;
        coll.material.bounciness = bounciness;
        rb_ = obj.GetComponent<Rigidbody2D>();
        rb_.mass = Weight;
        
	}
	
	// Update is called once per frame
	void Update () {

        //This was trying to get it working via Input actions
        if (Input.GetKey(KeyCode.I))
        {
            rb_.mass = Weight *2 ;
        }
        if (Input.GetKey("v")){
            //rb_.velocity = new Vector3(0, 10, 0);
            coll.material.bounciness = bounciness * 2;            
        }
        
    }
    void OnCollisionEnter(Collision collisionInfo)
    {
        //Here we want to when ever the object hits any sort of collider, we want it to bounce in the opposite direction, Tried using the addforce and reflect, could not get the direction bit working.

        Vector3 playerpos = this.transform.position;
        //relecteddirection.position = Vector3.Reflect(originaldirection.position, Vector3.right);
        
        //rb_.AddForce(Vector3.Reflect(direction, collisionInfo.contacts[0].normal * 5, ForceMode.Impulse));


    }
}
