﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level5 : MonoBehaviour {

    public Level1 Lev1;
    public Level3 Lev3;
    public Level4 Lev4;
    public Level2 Lev2;
    public MenuBack BackButton;

    public bool Clicked;
    public bool Back;
    float YVal;
    // Use this for initialization
    void Start()
    {
        YVal = transform.position.y + 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (Clicked && transform.position.y > YVal - 10)//get off screen
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.4f, transform.position.z);
        }

        if (Back)
        {
            Clicked = false;
            if (transform.position.y < YVal)//get on screen
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + 0.4f, transform.position.z);
            }
            else
            {
                Back = false;
                Clicked = false;
                transform.position = new Vector3(transform.position.x, YVal, transform.position.z);
            }
        }
    }

    IEnumerator StartLevel()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(6);
    }

    private void OnMouseUpAsButton()
    {
        if (!Clicked && !Back)
        {
            Clicked = true;
            BackButton.Clicked = true;
            Lev1.Clicked = true;
            Lev3.Clicked = true;
            Lev4.Clicked = true;
            Lev2.Clicked = true;
            StartCoroutine(StartLevel());
        }
    }
}
