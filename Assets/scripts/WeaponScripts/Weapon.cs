using UnityEngine;
using System.Collections;

public abstract class Weapon : MonoBehaviour
{
    public Transform shotSpawn;
    bool reloading, CurrentWeapon;
    public bool reloaded;
    float nextFire;

    public virtual void Fire(GameObject shotType, bool CurrentWeapon, ref int currentAmmo, float fireRate, int projectileAmount, int Spread)
    {
        if (Input.GetButtonDown("Fire") && Time.time > nextFire)
        {
            if (CurrentWeapon && currentAmmo >= 1 && !reloading)
            {
                currentAmmo -= 1;
                Quaternion[] Angle = new Quaternion[projectileAmount];

                GetComponent<AudioSource>().Play();

                nextFire = Time.time + fireRate;

                for (int i = 0; i < projectileAmount; i++)
                    Angle[i] = (Quaternion.AngleAxis(UnityEngine.Random.Range(-Spread, Spread), new Vector3(0, 1, 0)) * (shotSpawn.rotation));

                for (int i = 0; i < projectileAmount; i++)
                    Instantiate(shotType, shotSpawn.position, Angle[i]);
            }
        }
    }

    public virtual void Reload(int reloadTime)
    {
        if (!reloading)
        {
            StartCoroutine(Reloading(reloadTime));
            reloading = true;
        }
    }

    IEnumerator Reloading(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        reloaded = true;
        reloading = false;
    }
}
