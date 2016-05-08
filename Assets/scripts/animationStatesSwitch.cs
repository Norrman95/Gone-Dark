﻿using UnityEngine;
using System.Collections;

public class animationStatesSwitch : MonoBehaviour
{
    public Animator anim;
    public GameObject playerInfo;
    public bool movement;
    public pause checkpause;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        playerInfo = GameObject.Find("PlayerControls");
        checkpause = GameObject.Find("PauseObject").GetComponent<pause>();

    }


    void Update()
    {
        if (checkpause.canpause)
        {
            if (Input.GetKey("w") || Input.GetKey("d") || Input.GetKey("s") || Input.GetKey("a"))
            {
                movement = true;
            }
            else
                movement = false;



            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - pos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            // Debug.Log(angle);




            if (angle < 110 && angle > 80 && movement == true)
            {
                anim.Play("Back");


            }
            else if (angle < 110 && angle > 80)
            {
                anim.Play("Idle Back");
            }


            if (angle < 80 && angle > 30 && movement == true)
            {
                anim.Play("Halv-Side");

            }

            else if (angle < 80 && angle > 30)
            {
                anim.Play("Idle Halv Back");

            }

            if (angle < 30 && angle > 0 && movement == true)
            {
                anim.Play("Side");

            }

            else if (angle < 30 && angle > 0)
            {
                anim.Play("IDle S");

            }

            if (angle < 0 && angle > -25 && movement == true)
            {
                anim.Play("Halv-Front");

            }

            else if (angle < 0 && angle > -25)
            {
                anim.Play("Idle Halv Front");

            }

            if (angle < -25 && angle > -110 && movement == true)
            {
                anim.Play("Front");

            }

            else if (angle < -25 && angle > -110)
            {
                anim.Play("Idle Front");

            }


            if (angle < -110 && angle > -140 && movement == true)
            {
                anim.Play("Flipped Halv-Front");

            }
            else if (angle < -110 && angle > -140)
            {
                anim.Play("Flipped Idle Halv Front");

            }

            if (angle < -140 && angle > -170 && movement == true)
            {
                anim.Play("Flipped Side");

            }

            else if (angle < -140 && angle > -170)
            {
                anim.Play("Flipped Idle Side");

            }
            if (angle < 170 && angle > 110 && movement == true)
            {
                anim.Play("Flipped Halv-Side");

            }

            else if (angle < 170 && angle > 110)
            {
                anim.Play("Flipped Idle Halv Back");

            }

        }





    }
}
