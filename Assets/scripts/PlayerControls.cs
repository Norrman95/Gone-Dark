using UnityEngine;
using System.Collections;



public class PlayerControls : MonoBehaviour
{

    public float moveSpeed;
    private Vector3 input;
    private float maxSpeed;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    public bool pistol, shotgun, axe;

    void Update()
    {
        PlayerMovement();
        Fire();
        Swapweapons();
    }

    void Fire()
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


                Quaternion Angle1 = (Quaternion.AngleAxis(Random.Range(-15, 15), new Vector3(0, 1, 0)) * (shotSpawn.rotation));
                Quaternion Angle2 = (Quaternion.AngleAxis(Random.Range(-15, 15), new Vector3(0, 1, 0)) * (shotSpawn.rotation));
                Quaternion Angle3 = (Quaternion.AngleAxis(Random.Range(-15, 15), new Vector3(0, 1, 0)) * (shotSpawn.rotation));
                Quaternion Angle4 = (Quaternion.AngleAxis(Random.Range(-15, 15), new Vector3(0, 1, 0)) * (shotSpawn.rotation));
                Quaternion Angle5 = (Quaternion.AngleAxis(Random.Range(-15, 15), new Vector3(0, 1, 0)) * (shotSpawn.rotation));

                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, Angle1);
                Instantiate(shot, shotSpawn.position, Angle2);
                Instantiate(shot, shotSpawn.position, Angle3);
                Instantiate(shot, shotSpawn.position, Angle4);
                Instantiate(shot, shotSpawn.position, Angle5);
            }
            if (axe)
            {

            }
        }
    }

    void Swapweapons()
    {
        if (Input.GetButton("pistol"))
        {
            pistol = true;
            shotgun = false;
            axe = false;
        }

        if (Input.GetButton("shotgun"))
        {
            pistol = false;
            shotgun = true;
            axe = false;
        }
        if (Input.GetButton("Axe"))
        {
            pistol = false;
            shotgun = false;
            axe = true;
        }
    }

    void PlayerMovement()
    {
        if (Input.GetButton("Sprint"))
        {
            maxSpeed = 25f;
        }
        else
        {
            maxSpeed = 5f;
        }

        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {

            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }
    }
}
