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

    bool Reloading = false;

    public bool pistol, shotgun, axe;
    public int pistolMag, totalshotgunAmmo;
    public int currentpistolAmmo, currentshotgunAmmo;
    public bool carriesPistol, carriesShotgun, carriesAxe;

    void Update()
    {
        executeReload();
        PlayerMovement();
        Fire();
        Swapweapons();
    }

    private void executeReload()
    {
        if (Input.GetButtonDown("Reload"))
        {
            StartCoroutine(Wait(2));
        }
    }

    private IEnumerator Wait(float seconds)
    {
        if(pistol)
        currentpistolAmmo = 0;

        if(shotgun)
        currentshotgunAmmo = 0;

        yield return new WaitForSeconds(seconds);
        Reload();
    }

    void Reload()
    {
        if (pistol && currentpistolAmmo < 8 && pistolMag >= 1)
        {           
            pistolMag -= 1;
            currentpistolAmmo = 8;
        }
        if (shotgun && totalshotgunAmmo >= 1)
        {
            if (totalshotgunAmmo == 1)
            {
                totalshotgunAmmo -= 1;
                currentshotgunAmmo = 1;
                return;
            }
            if (currentshotgunAmmo == 1)
            {
                totalshotgunAmmo -= 1;
                currentshotgunAmmo = 2;
            }
            if (currentshotgunAmmo == 0)
            {
                totalshotgunAmmo -= 2;
                currentshotgunAmmo = 2;
            }
        }
    }



    void Fire()
    {
        if (Input.GetButtonDown("Fire") && Time.time > nextFire)
        {
            if (pistol && currentpistolAmmo >= 1 && carriesPistol)
            {
                nextFire = Time.time + fireRate;
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);

                currentpistolAmmo -= 1;
            }
            if (shotgun && currentshotgunAmmo >= 1 && carriesShotgun)
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

                currentshotgunAmmo -= 1;
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
