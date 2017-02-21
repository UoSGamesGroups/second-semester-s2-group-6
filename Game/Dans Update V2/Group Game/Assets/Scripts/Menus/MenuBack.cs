using UnityEngine;
using System.Collections;

public class MenuBack : MonoBehaviour {
    public MenuTutorial TutButton;
    public MenuLevels LvlButton;
    public bool Clicked;
    public bool Back;
    float XVal;
    public Level1 Level1;
    public Level2 Level2;
    public Level3 Level3;
    public Level4 Level4;
    public Level5 Level5;
    // Use this for initialization
    void Start()
    {
        XVal = transform.position.x+10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Clicked && transform.position.x > XVal-10)//get off screen
        {
            transform.position = new Vector3(transform.position.x-0.4f, transform.position.y , transform.position.z);
        }

        if (Back)
        {
            Clicked = false;
            if (transform.position.x < XVal)//get on screen
            {
                transform.position = new Vector3(transform.position.x + 0.4f, transform.position.y, transform.position.z);
            }
            else
            {
                Back = false;
                Clicked = false;
            }
        }
    }


    private void OnMouseUpAsButton()
    {
        if (!Clicked && !Back)
        {
            Clicked = true;
            TutButton.Back = true;
            LvlButton.Back = true;
            Level1.Clicked = true;
            Level2.Clicked = true;
            Level3.Clicked = true;
            Level4.Clicked = true;
            Level5.Clicked = true;

        }
    }



}
