using UnityEngine;
using System.Collections;

public class LightRays : MonoBehaviour
{
    RaycastHit hit;
    EnemyAi[] Enemy = new EnemyAi[8];

    void Start()
    {
        for (int i = 0; i < Enemy.Length; i++)
        {
            string ConvertedString = i.ToString();
            Enemy[i] = GameObject.Find("Enemy (" + ConvertedString + ")").GetComponent<EnemyAi>();
        }
    }

    void Update()
    {
        Rays();
    }

    void Rays()
    {
        Quaternion Angle1 = Quaternion.AngleAxis(-15, new Vector3(0, 1, 0));
        Quaternion Angle2 = Quaternion.AngleAxis(15, new Vector3(0, 1, 0));
        Quaternion Angle3 = Quaternion.AngleAxis(-30, new Vector3(0, 1, 0));
        Quaternion Angle4 = Quaternion.AngleAxis(30, new Vector3(0, 1, 0));

        Vector3[] rayDir = new Vector3[5];
        rayDir[0] = transform.TransformDirection(Vector3.forward);
        rayDir[1] = Angle1 * rayDir[0];
        rayDir[2] = Angle2 * rayDir[0];
        rayDir[3] = Angle3 * rayDir[0];
        rayDir[4] = Angle4 * rayDir[0];

        Debug.DrawRay(transform.position, rayDir[0] * 15);
        Debug.DrawRay(transform.position, Angle1 * rayDir[0] * 15);
        Debug.DrawRay(transform.position, Angle2 * rayDir[0] * 15);
        Debug.DrawRay(transform.position, Angle3 * rayDir[0] * 15);
        Debug.DrawRay(transform.position, Angle4 * rayDir[0] * 15);

        for (int i = 0; i < rayDir.Length; i++)
        {
            if (Physics.Raycast(transform.position, rayDir[i], out hit, 15))
            {
                if (hit.transform.gameObject.GetComponent<EnemyAi>())
                {
                    hit.transform.gameObject.GetComponent<EnemyAi>().Sight_Range = 100;
                    hit.transform.gameObject.GetComponent<EnemyAi>().Sight_Range = 180;
                }
            }
        }
    }
}
