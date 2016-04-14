using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour
{
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;
    private Rigidbody rb;
    public float speed;

    public bool pistol, shotgun, axe;

    void Update()
    {
        if (Input.GetButton("Fire") && Time.time > nextFire)
        {
            if (pistol)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
            if (shotgun)
            {

            }
            if (axe)
            {

            }
        }


        if (Input.GetButton("pistol"))
        {
            pistol = true;
        }

        if (Input.GetButton("shotgun"))
        {
            shotgun = true;
        }
        if (Input.GetButton("Axe"))
        {
            axe = true;
        }

    }

    void Pistol()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void Shotgun()
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

        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }

    void Axe()
    {

    }
}
