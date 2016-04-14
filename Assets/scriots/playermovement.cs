using UnityEngine;
using System.Collections;



public class playermovement : MonoBehaviour
{

    public float moveSpeed;
    private Vector3 input;
    private float maxSpeed;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    private float nextFire;

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }

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
