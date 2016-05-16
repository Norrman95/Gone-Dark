using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
    private float moveSpeed;
    private Vector3 input;
    private float maxSpeed;
    public GameObject PistolShot, ShotgunShot;
    public Transform shotSpawn;

    private Quaternion[] Angle = new Quaternion[9];
    private bool canFirePistol, canFireShotgun, canReloadPistol, canReloadShotgun;
    private bool reloading, usingMedkit = false;
    private float fireRate, nextFire;
    private int addedShells;

    void Update()
    {
        PlayerMovement();
        AvailableAction();
        Reloading();
        UsingMedkit();
        Fire();
    }

    private void Reloading()
    {
        if (Input.GetButtonDown("Reload"))
        {
            StartCoroutine(Wait(2));
            reloading = true;
        }
    }

    public void PlaySound(int number)
    {

        if (number == 1)
        {
            GetComponent<AudioSource>().Play();
        }


    }
    private void UsingMedkit()
    {
        if (Input.GetButtonDown("Medkit"))
        {
            StartCoroutine(Wait(5));
            usingMedkit = true;
        }
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (reloading)
        {
            Reloaded();
            reloading = false;
        }
        if (usingMedkit)
        {
            UsedMedkit();
            usingMedkit = false;
        }
    }

    void Reloaded()
    {
        if (canReloadPistol)
        {
            GetComponent<PlayerInventory>().pistolMag -= 1;
            GetComponent<PlayerInventory>().currentpistolAmmo = 8;
        }
        if (canReloadShotgun)
        {
            int maxShells = 2;
            addedShells = maxShells - GetComponent<PlayerInventory>().currentShells;

            if (GetComponent<PlayerInventory>().totalShells > 1)
            {
                GetComponent<PlayerInventory>().totalShells -= addedShells;
                GetComponent<PlayerInventory>().currentShells += addedShells;
            }
            else
            {
                GetComponent<PlayerInventory>().totalShells = 0;
                GetComponent<PlayerInventory>().currentShells += 1;
            }
        }
    }

    void UsedMedkit()
    {
        GetComponent<PlayerInfo>().AdjustHP(20);
        GetComponent<PlayerInventory>().medkitAmount -= 1;
    }


    void Fire()
    {
        if (Input.GetButtonDown("Fire") && Time.time > nextFire)
        {
            if (canFirePistol)
            {

                PlaySound(1);
                fireRate = 0.25f;
                nextFire = Time.time + fireRate;

                Instantiate(PistolShot, shotSpawn.position, shotSpawn.rotation);

                GetComponent<PlayerInventory>().currentpistolAmmo -= 1;
            }
            if (canFireShotgun)
            {
                fireRate = 0;
                nextFire = Time.time + fireRate;
                PlaySound(1);
                for (int i = 0; i < 9; i++)
                    Instantiate(ShotgunShot, shotSpawn.position, Angle[i]);


                GetComponent<PlayerInventory>().currentShells -= 1;
            }
        }
    }

    void PlayerMovement()
    {
        if (Input.GetButton("Sprint") && GetComponent<PlayerInfo>().currentStamina >= 1)
        {
            GetComponent<PlayerInfo>().running = true;
            moveSpeed = 15;
        }

        else
        {
            GetComponent<PlayerInfo>().running = false;
            moveSpeed = 50f;
        }

        //input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        //if (GetComponent<Rigidbody>().velocity.magnitude < maxSpeed)
        //{

        //    GetComponent<Rigidbody>().AddForce(input * moveSpeed);
        //}

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.forward * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
    }














    void AvailableAction()
    {
        if (GetComponent<PlayerInventory>().pistol && GetComponent<PlayerInventory>().currentpistolAmmo >= 1)
        {
            canFirePistol = true;
        }
        else
        {
            canFirePistol = false;
        }
        if (GetComponent<PlayerInventory>().pistol && GetComponent<PlayerInventory>().currentpistolAmmo < 8 && GetComponent<PlayerInventory>().pistolMag >= 1)
        {
            canReloadPistol = true;
        }
        else
        {
            canReloadPistol = false;
        }


        if (GetComponent<PlayerInventory>().shotgun && GetComponent<PlayerInventory>().currentShells >= 1 && GetComponent<PlayerInventory>().carriesShotgun)
        {
            for (int i = 0; i < 9; i++)
            {
                Angle[i] = (Quaternion.AngleAxis(UnityEngine.Random.Range(-15, 15), new Vector3(0, 1, 0)) * (shotSpawn.rotation));
            }
            canFireShotgun = true;
        }
        else
        {
            canFireShotgun = false;
        }
        if (GetComponent<PlayerInventory>().shotgun && GetComponent<PlayerInventory>().totalShells >= 1)
        {
            canReloadShotgun = true;
        }
        else
        {
            canReloadShotgun = false;
        }

        if (reloading)
        {
            canFirePistol = false;
            canFireShotgun = false;
        }
    }
}
