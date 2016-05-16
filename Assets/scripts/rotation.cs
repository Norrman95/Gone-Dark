using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour
{
    Ray cameraRay;
    RaycastHit camerarayhit;

    void Update()
    {
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out camerarayhit, Mathf.Infinity, 1 << 8))
        {
            if (camerarayhit.transform.tag == "RaycastCube")
            {

                Vector3 targetPos = new Vector3(camerarayhit.point.x, transform.position.y, camerarayhit.point.z);
                transform.LookAt(targetPos);
            }
        }
    }
}
