﻿using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour
{
    bool canpause;
    private GameObject raycube;
    private Animator animate;
    private GUIContent content;
    private SaveLoadGame savedGame;
    
    void Start()
    {
        savedGame = gameObject.GetComponent<SaveLoadGame>();

        canpause = true;
        raycube = GameObject.Find("RayCube");
        animate = GameObject.Find("walkSpritesheet_0").GetComponent<Animator>();
    }




    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canpause)
            {

                Time.timeScale = 0;
                canpause = false;
                raycube.SetActive(false);
                animate.enabled = false;
                
            }
            else
            {
                Time.timeScale = 1;
                canpause = true;
                raycube.SetActive(true);
                animate.enabled = true;
            }
        }
    }

    void OnGUI()
    {
        if (!canpause)
        {

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 250, 50), "Resume"))
            {
                Time.timeScale = 1;
                canpause = true;
                raycube.SetActive(true);
                animate.enabled = true;

            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 75, 250, 50), "Save Game"))
            {
                savedGame.Save();
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 125, 250, 50), "Exit Game"))
            {
                Application.Quit();
            }

        }
    }













}
