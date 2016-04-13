using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour
{
    bool canpause;
    void Start()
    {
        canpause = true;
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canpause)
            {
                Time.timeScale = 0;
                canpause = false;
               
               
            }
            else
            {
                Time.timeScale = 1;
                canpause = true;
            }
        }
    }















}
