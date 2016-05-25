using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class LightRays : MonoBehaviour
{
    Ray cameraRay;
    RaycastHit camerarayhit, hit;
    pause checkpause;

    void Start()
    {

    }

    void Update()
    {
        if (Rays())
        {
            increaseRange();
        }
    }

    void increaseRange()
    {
        AICharacterControl.Sight_Range =50;
        AICharacterControl.Sight_Width = 90;
    }

    bool Rays()
    {
        Quaternion Angle1 = Quaternion.AngleAxis(-15, new Vector3(0, 1, 0));
        Quaternion Angle2 = Quaternion.AngleAxis(15, new Vector3(0, 1, 0));
        Quaternion Angle3 = Quaternion.AngleAxis(-30, new Vector3(0, 1, 0));
        Quaternion Angle4 = Quaternion.AngleAxis(30, new Vector3(0, 1, 0));

        Vector3 rayDir1 = transform.TransformDirection(Vector3.forward);
        Vector3 rayDir2 = Angle1 * rayDir1;
        Vector3 rayDir3 = Angle2 * rayDir1;
        Vector3 rayDir4 = Angle3 * rayDir1;
        Vector3 rayDir5 = Angle4 * rayDir1;

        Debug.DrawRay(transform.position, rayDir1 * 15);
        Debug.DrawRay(transform.position, Angle1 * rayDir1 * 15);
        Debug.DrawRay(transform.position, Angle2 * rayDir1 * 15);
        Debug.DrawRay(transform.position, Angle3 * rayDir1 * 15);
        Debug.DrawRay(transform.position, Angle4 * rayDir1 * 15);

        if (Physics.Raycast(transform.position, rayDir1, out hit, 15))
        {
            if (hit.transform.tag == "Enemy")
            {
                return true;
            }
        }
        if (Physics.Raycast(transform.position, rayDir2, out hit, 15))
        {
            if (hit.transform.tag == "Enemy")
            {
                return true;
            }
        }
        if (Physics.Raycast(transform.position, rayDir3, out hit, 15))
        {
            if (hit.transform.tag == "Enemy")
            {
                return true;
            }
        }
        if (Physics.Raycast(transform.position, rayDir4, out hit, 15))
        {
            if (hit.transform.tag == "Enemy")
            {
                return true;
            }
        }
        if (Physics.Raycast(transform.position, rayDir5, out hit, 15))
        {
            if (hit.transform.tag == "Enemy")
            {
                return true;
            }
        }
        return false;
    }
}
