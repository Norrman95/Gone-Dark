using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour {

        Ray cameraRay;
        RaycastHit camerarayhit;
       


	// Use this for initialization
	void Start ()
        {
          

      
	}
	
	// Update is called once per frame
	void Update () {

        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);


        if(Physics.Raycast(cameraRay, out camerarayhit))
        {
            //if (camerarayhit.transform.tag == "Ground")
            //{

                Vector3 targetPos = new Vector3(camerarayhit.point.x, transform.position.y, camerarayhit.point.z);
                transform.LookAt(targetPos);
            //}
        }
	
	}
}
