using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour
{
    public bool pistol, shotgun, axe, pistolMag, shotgunAmmo, medkit, key;
    public int pistolMagAmount, shotgunAmmoAmount, medkitAmount;
    private bool canPickUp;

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canPickUp = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            canPickUp = true;
        }
        if (canPickUp)
            Pickup(other);
    }

    void Pickup(Collider other)
    {
        if (pistol)
        {
            other.GetComponent<PlayerControls>().carriesPistol = true;
            DestroyObject(gameObject);
        }
        if (shotgun)
        {
            other.GetComponent<PlayerControls>().carriesShotgun = true;
            DestroyObject(gameObject);
        }
        if (axe)
        {
            other.GetComponent<PlayerControls>().carriesAxe = true;
            DestroyObject(gameObject);
        }

        if (pistolMag)
        {
            other.GetComponent<PlayerControls>().pistolMag += pistolMagAmount;
            DestroyObject(gameObject);
        }
        if (shotgunAmmo)
        {
            other.GetComponent<PlayerControls>().totalshotgunAmmo += shotgunAmmoAmount;
            DestroyObject(gameObject);
        }
        if (medkit)
        {

        }

        if (key)
        {

        }
    }
}

