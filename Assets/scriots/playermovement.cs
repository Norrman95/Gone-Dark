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
    public bool spotted = false;


    //UnityStandardAssets.Characters.ThirdPerson.AICharacterControl Enemy = new UnityStandardAssets.Characters.ThirdPerson.AICharacterControl();  



    // Use this for initialization
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {

        //cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //if (Physics.Raycast(cameraRay, out camerarayhit))
        //{
        //    Vector3 targetPos = new Vector3(camerarayhit.point.x, transform.position.y, camerarayhit.point.z);
        //    transform.LookAt(targetPos);
        //}

        //En raycast som kollar framför spelaren

        //Vector3 fwd = transform.TransformDirection(Vector3.forward);
        //if (Physics.Raycast(transform.position, fwd, 10))
        //{
        //    agent.enabled = true;
        //    print("spotted");

        ////}
        if (Input.GetButton("Sprint"))
        {
            maxSpeed = 25f;
        }
        else
        {
            maxSpeed = 5f;
        }


        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }


        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        {

            GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        }

        //Vector3 mousePos = Input.mousePosition;
        //mousePos.z = Camera.main.nearClipPlane;
        //Vector3 MS = Camera.main.ScreenToWorldPoint(mousePos);
        //MS.y = transform.position.y;
        //transform.LookAt(MS);

    }
}
