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
        {
            Pickup(other);
        }
    }

    void Pickup(Collider other)
    {
        if (shotgun)
        {
            other.GetComponent<PlayerInventory>().carriesShotgun = true;
            DestroyObject(gameObject);
        }
        if (axe)
        {
            other.GetComponent<PlayerInventory>().carriesAxe = true;
            DestroyObject(gameObject);
        }

        if (pistolMag)
        {
            other.GetComponent<PlayerInventory>().pistolMag += pistolMagAmount;
            DestroyObject(gameObject);
        }
        if (shotgunAmmo)
        {
            other.GetComponent<PlayerInventory>().totalShells += shotgunAmmoAmount;
            DestroyObject(gameObject);
        }
        if (medkit)
        {
            other.GetComponent<PlayerInventory>().medkitAmount += medkitAmount;
            DestroyObject(gameObject);
        }

        if (key)
        {

        }
    }
}

