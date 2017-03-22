using UnityEngine;
using System.Collections;

public class TutorialPlayerControl : MonoBehaviour {
    bool Up = false;
    bool Left = false;
    bool Right = false;

    public bool Finish = false;
    bool OnGround = false;
    public Rigidbody2D RigBody;
    float JumpHeight=8;
    float XSpeed=3;
    public GUISkin theSkin;
    string msg ="";
    public TutorialCameraControl Cam;


    // Use this for initialization
    void Start () {
        RigBody = GetComponent<Rigidbody2D>();
        msg = "Hi, Welcome to the tutorial";
        StartCoroutine(Timer());
	}
	
	// Update is called once per frame
	void Update () {
        if(Up && OnGround == true)
        {
            OnGround = false;
            RigBody.velocity = new Vector2(RigBody.velocity.x, JumpHeight * RigBody.gravityScale);
        }


        if (Left)
        {
            transform.position = new Vector2(transform.position.x - (XSpeed * Time.deltaTime) * RigBody.gravityScale, transform.position.y);
        }

        if (Right)
        {
            transform.position = new Vector2(transform.position.x + (XSpeed * Time.deltaTime) * RigBody.gravityScale, transform.position.y);
        }

        if (Finish)
        {
            if (transform.position.x < 0)
            {
                Left = true;
            }
            else
            {
                Right = true;
            }
            Finish = false;
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(3);
        //instantiate buttons
        Left = true;
        msg = "Left";
        yield return new WaitForSeconds(2);
        Left = false;
        yield return new WaitForSeconds(1);
        Right = true;
        msg = "Right";
        yield return new WaitForSeconds(2);
        Right = false;
        yield return new WaitForSeconds(1);
        Up = true;
        msg = "Jump";
        yield return new WaitForSeconds(1);
        Up = false;
        msg = "Gravity Shift";
        Up = true;
        yield return new WaitForSeconds(1);
        Up = false;
        Cam.Space = true;
        yield return new WaitForSeconds(0.4f);
        Cam.Space = false;
        yield return new WaitForSeconds(2);
        msg = "Boulders activate switches";
        yield return new WaitForSeconds(4);
        Finish = true;
        msg = "Touch the door to finish";

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

    private void OnTriggerExit2D(Collider2D coll)
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

    private void OnGUI()
    {
        GUI.skin = theSkin;
        GUI.Label(new Rect(Screen.width * 0.48f, Screen.height * (8 / 9), 100, 100), msg);
    }
}
