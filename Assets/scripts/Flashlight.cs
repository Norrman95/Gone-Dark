using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Flashlight : MonoBehaviour {



  
    public GameObject goPlayer;

    Ray cameraRay;
    RaycastHit camerarayhit;
	void Start () 
    {
       Ray lightdirection = new Ray(transform.position, Vector3.forward * 30);

     
	}

	// Update is called once per frame
	void Update () 
    {


    
                 

        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.DrawRay(transform.position, transform.forward * 30);

        if (Physics.Raycast(cameraRay, out camerarayhit))
        {
            //if (camerarayhit.transform.tag == "Anim-Switch Halv-Front")
            //{

            //    anim.SetTrigger("Front - HalvFront");


            //    //Vector3 targetPos = new Vector3(camerarayhit.point.x, transform.position.y, camerarayhit.point.z);
            //    //transform.LookAt(targetPos);
            //}
        }

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
