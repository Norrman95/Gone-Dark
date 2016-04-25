using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Flashlight : MonoBehaviour 
{
    public GameObject goPlayer;

    Ray cameraRay;
    RaycastHit camerarayhit;

	void Start () 
    {
       Ray lightdirection = new Ray(transform.position, Vector3.forward * 30);  
	}

	void Update () 
    {
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Input.GetKeyDown(KeyCode.F))
        {
            if(GetComponent<Light>().enabled == false)
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
