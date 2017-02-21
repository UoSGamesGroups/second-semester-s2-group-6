using UnityEngine;
using System.Collections;

public class MenuLevels : MonoBehaviour {
    public MenuTutorial TutButton;
    public Level1 Level1;
    public Level2 Level2;
    public Level3 Level3;
    public Level4 Level4;
    public Level5 Level5;
    public MenuBack BackButton;
    public bool Clicked;
    public bool Back;
    float YVal;
	// Use this for initialization
	void Start () {
        YVal = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (Clicked && transform.position.y < YVal+10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
        }

        if (Back)
        {
            Clicked = false;
            if (transform.position.y > YVal)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);

            }
            else {
                Back = false;
                transform.position = new Vector3(transform.position.x, YVal, transform.position.z);
            }
        }
	}


    private void OnMouseUpAsButton()
    {
        if (!Clicked)
        {
            TutButton.Clicked = true;
            BackButton.Back = true;
            Level1.Back = true;
            Level2.Back = true;
            Level3.Back = true;
            Level4.Back = true;
            Level5.Back = true;
            Clicked = true;
        }
    }



}
