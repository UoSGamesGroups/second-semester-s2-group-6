using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour
{

    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Right;
    public KeyCode Left;
    public float XSpeed;
    public float JumpHeight;
    public bool Home = false;
    public bool OnGround = false;
    public Rigidbody2D RigBody;
    // Use this for initialization
    void Start()
    {
        RigBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Up) && OnGround == true)
        {
            OnGround = false;
            RigBody.velocity = new Vector2(RigBody.velocity.x, JumpHeight * RigBody.gravityScale);
        }


        if (Input.GetKey(Left))
        {
            transform.position = new Vector2(transform.position.x - (XSpeed * Time.deltaTime) * RigBody.gravityScale, transform.position.y);
        }

        if (Input.GetKey(Right))
        {
            transform.position = new Vector2(transform.position.x + (XSpeed * Time.deltaTime) * RigBody.gravityScale, transform.position.y);
        }



    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (RigBody.gravityScale == 1 && coll.gameObject.tag == "GIs1")
        {
            OnGround = true;
        }

        else if (RigBody.gravityScale == -1 && coll.gameObject.tag == "GIs-1")
        {
            OnGround = true;

        }

    }

    private void OnTriggerExit2D(Collider coll)
    {
        if (RigBody.gravityScale == 1)
        {
            if (coll.gameObject.tag == "GIs1")
            {
                OnGround = false;
            }
        }
        else if (RigBody.gravityScale == -1)
        {
            if (coll.gameObject.tag == "GIs-1")
            {
                OnGround = false;
            }
        }
    }
}
