using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Flashlight : MonoBehaviour
{
    public GameObject goPlayer;

    Ray cameraRay;
    RaycastHit camerarayhit;
    pause checkpause;

    void Start()
    {
        Ray lightdirection = new Ray(transform.position, Vector3.forward * 30);
        checkpause = GameObject.Find("PauseObject").GetComponent<pause>();
    }

    void Update()
    {
        if (checkpause.canpause)
        {
            cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if (GetComponent<Light>().enabled == false)
                {
                    GetComponent<Light>().enabled = true;
                }
                else
                {
                    GetComponent<Light>().enabled = false;
                }
            }
        }

    }
}
