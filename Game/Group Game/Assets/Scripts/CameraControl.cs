using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour
{
    public KeyCode Space;
    public bool Rotating = false;
    public PlayerControl[] Players;
    public int DesiredRotation = 0;
    public float SpinLimit = 2;
    public Rigidbody2D Rb;
    public GameObject[] Shapes;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(Space) && Rotating == false)
        {
            Rotating = true;
            if (Players[1].RigBody.gravityScale == 1)
            {
                DesiredRotation = 180;
            }
            else
            {
                DesiredRotation = 0;
            }

            for (int i = 0; i < Players.Length; i++)
            {
                Players[i].RigBody.gravityScale = 0;
                Players[i].RigBody.velocity = new Vector2(0, 0);
                Players[i].enabled = false;
            }
            for (int i = 0; i < Shapes.Length; i++)
            {
                Rb = Shapes[i].GetComponent<Rigidbody2D>();
                Rb.gravityScale = 0;
                Rb.velocity = new Vector2(0, 0);
            }
        }

        if (Rotating == true)
        {
            //slerp

            Quaternion target = Quaternion.Euler(0, 0, DesiredRotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 4.0f);

            if (transform.rotation.z * -180 < DesiredRotation + SpinLimit && transform.rotation.z * -180 > DesiredRotation - SpinLimit)
            {
                transform.rotation = new Quaternion(transform.rotation.x, transform.rotation.y, DesiredRotation, transform.rotation.w);
                Rotating = false;
                for (int i = 0; i < Players.Length; i++)
                {
                    Players[i].enabled = true;
                    if (DesiredRotation == 0)
                    {
                        Players[i].RigBody.gravityScale = 1;
                    }

                    else
                    {
                        Players[i].RigBody.gravityScale = -1;
                    }
                }

                for (int i = 0; i < Shapes.Length; i++)
                {
                    Rb = Shapes[i].GetComponent<Rigidbody2D>();
                    if (DesiredRotation == 0)
                    {

                        Rb.gravityScale = 1;
                    }
                    else
                    {
                        Rb.gravityScale = -1;
                    }
                }
            }
        }
    }
}
