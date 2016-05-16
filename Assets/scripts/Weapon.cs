using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
    GameObject shot;
    public Transform shotSpawn;
    int currentAmmo, projectileAmount;
    float fireRate, nextFire;
    bool reloading, canFire, CurrentWeapon;
    public bool reloaded;

    public virtual void Start(GameObject shot, int projectileAmount, float fireRate)
    {
        this.projectileAmount = projectileAmount;
        this.shot = shot;
        this.fireRate = fireRate;
    }

    public virtual void Fire(ref int currentAmmo, int Spread)
    {
        if (Input.GetButtonDown("Fire") && Time.time > nextFire)
        {
            if (canFire)
            {
                currentAmmo -= 1;
                Quaternion[] Angle = new Quaternion[projectileAmount];

                PlaySound(1);
                nextFire = Time.time + fireRate;

                for (int i = 0; i < projectileAmount; i++)
                    Angle[i] = (Quaternion.AngleAxis(UnityEngine.Random.Range(-Spread, Spread), new Vector3(0, 1, 0)) * (shotSpawn.rotation));

                for (int i = 0; i < projectileAmount; i++)
                    Instantiate(shot, shotSpawn.position, Angle[i]);
            }
        }
    }

    public virtual void AvailableAction(bool CurrentWeapon, int currentAmmo)
    {
        if (CurrentWeapon && currentAmmo >= 1)
        {
            canFire = true;
        }
        else
        {
            canFire = false;
        }

        if (reloading)
        {
            canFire = false;
        }
    }

    public virtual void PlaySound(int number)
    {
        GetComponent<AudioSource>().Play();
    }

    public virtual void Reload(int reloadTime)
    {
        StartCoroutine(Reloading(reloadTime));
        reloading = true;
    }
    IEnumerator Reloading(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        reloaded = true;
        reloading = false;
    }
}
