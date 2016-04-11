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
    void increaseRange()
    {
        AICharacterControl.Sight_Range = 100;
        AICharacterControl.Sight_Width = 100;
    }

    void CanSeePlayer()
    {
        Vector3 startVec = transform.position;
        Vector3 startVecFwd = transform.forward;

        RaycastHit hit;
        Vector3 rayDirection = transform.position - startVec;

        if ((Vector3.Angle(rayDirection, startVecFwd)) < 90 && (Vector3.Distance(startVec, transform.position) <= 5))
            if (Physics.Raycast(startVec, rayDirection, out hit, 100f))
            {
                if (hit.transform.tag == "Enemy")
                    print("I saw him");
                    increaseRange();
            }
    }
	// Update is called once per frame
	void Update () 
    {


    
                 

        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(transform.position, transform.forward * 30);

        if (Physics.Raycast(cameraRay, out camerarayhit))
        {
            //if (camerarayhit.transform.tag == "Anim-Switch Halv-Front")
            //{

            //    anim.SetTrigger("Front - HalvFront");


            //    //Vector3 targetPos = new Vector3(camerarayhit.point.x, transform.position.y, camerarayhit.point.z);
            //    //transform.LookAt(targetPos);
            //}
        }

        if(Input.GetKeyDown(KeyCode.E))
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
