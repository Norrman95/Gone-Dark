using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Flashlight : MonoBehaviour {



  
    public GameObject goPlayer;

    Ray cameraRay;
    RaycastHit camerarayhit, hit;
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
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        
        Quaternion spreadAngle = Quaternion.AngleAxis(-15, new Vector3(0, 1, 0));
        Quaternion spreadAngle2 = Quaternion.AngleAxis(15, new Vector3(0, 1, 0));
        Quaternion spreadAngle3 = Quaternion.AngleAxis(-30, new Vector3(0, 1, 0));
        Quaternion spreadAngle4 = Quaternion.AngleAxis(30, new Vector3(0, 1, 0));
        
        Vector3 newVector = spreadAngle * fwd;
        Vector3 newVector2 = spreadAngle2 * fwd;
        Vector3 newVector3 = spreadAngle3 * fwd;
        Vector3 newVector4 = spreadAngle4 * fwd;

        Ray ray = new Ray(transform.position, newVector);

        Debug.DrawRay(transform.position, fwd * 15);
        Debug.DrawRay(transform.position, spreadAngle * fwd * 15);
        Debug.DrawRay(transform.position, spreadAngle2 * fwd * 15);
        Debug.DrawRay(transform.position, spreadAngle3 * fwd * 15);
        Debug.DrawRay(transform.position, spreadAngle4 * fwd * 15);

        if (Physics.Raycast(transform.position, fwd, out hit, 15) || Physics.Raycast(transform.position, newVector, out hit, 15) || Physics.Raycast(transform.position, newVector2, out hit, 15) || Physics.Raycast(transform.position, newVector3, out hit, 15) || Physics.Raycast(transform.position, newVector4, out hit, 15))
        {
            if (hit.transform.tag == "Enemy")
            {
                print("There is something in front of the object!");
            }
        }
    }

	// Update is called once per frame
	void Update () 
    {
        CanSeePlayer();

    
                 

        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

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
