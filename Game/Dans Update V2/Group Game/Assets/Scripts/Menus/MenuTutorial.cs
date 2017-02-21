using UnityEngine;
using System.Collections;

public class MenuTutorial : MonoBehaviour {

    public MenuLevels LvlButton;
    public bool Clicked;
    public bool Back;
    float YVal;
    // Use this for initialization
    void Start()
    {
        YVal = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Clicked && transform.position.y > YVal-10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
        }

        if (Back)
        {
            Clicked = false;
            if (transform.position.y < YVal-0.5)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);

            }
            else
            {
                Back = false;
                transform.position = new Vector3(transform.position.x, YVal, transform.position.z);
            }
        }
    }


    private void OnMouseUpAsButton()
    {
        if (!Clicked)
        {
            Clicked = true;
            LvlButton.Clicked = true;
            StartCoroutine(StartLevel());
        }
    }

    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(2);
        Application.LoadLevel(1);
    }



}
