using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour
{
    public bool pistol, shotgun, pistolMag, shotgunAmmo, medkit, redKeycard, blueKeycard, yellowKeycard;
    public int pistolMagAmount, shotgunAmmoAmount, medkitAmount;
    private bool canPickUp;
    public bool pickedUp;

    public void saveItemstatus(int i)
    {
        PlayerPrefs.SetInt("pickedUp"+ i, (pickedUp ? 1 : 0));
    }
    public void loadItemstatus(int i)
    {
        pickedUp = (PlayerPrefs.GetInt("pickedUp"+ i) != 0);
    }

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
        if (pistolMag)
        {
            other.GetComponent<PlayerInventory>().pistolMag += pistolMagAmount;
            pickedUp = true;
        }
        if (shotgunAmmo)
        {
            other.GetComponent<PlayerInventory>().totalShells += shotgunAmmoAmount;
            pickedUp = true;
        }
        if (medkit)
        {
            other.GetComponent<PlayerInventory>().medkitAmount += medkitAmount;
            pickedUp = true;
        }

        if (redKeycard)
        {
            other.GetComponent<PlayerInventory>().redKeycard = true;
            pickedUp = true;
        }
        if (blueKeycard)
        {
            other.GetComponent<PlayerInventory>().blueKeycard = true;
            pickedUp = true;
        }
        if (yellowKeycard)
        {
            other.GetComponent<PlayerInventory>().yellowKeycard = true;
            pickedUp = true;
        }
    }
}

