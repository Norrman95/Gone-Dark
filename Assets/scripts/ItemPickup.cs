using UnityEngine;
using System.Collections;

public class ItemPickup : MonoBehaviour
{
    public bool pistol, shotgun, pistolMag, shotgunAmmo, medkit, redKeycard, blueKeycard, yellowKeycard, pickedUp;
    public int Amount;

    public void saveItemstatus(int i)
    {
        PlayerPrefs.SetInt("pickedUp"+ i, (pickedUp ? 1 : 0));
    }
    public void loadItemstatus(int i)
    {
        pickedUp = (PlayerPrefs.GetInt("pickedUp"+ i) != 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Pickup(other);
            pickedUp = true;
        }
    }

    void Pickup(Collider other)
    {
        if (pistolMag)
        {
            other.GetComponent<PlayerInventory>().pistolMag += Amount;            
        }
        if (shotgunAmmo)
        {
            other.GetComponent<PlayerInventory>().totalShells += Amount;
        }
        if (medkit)
        {
            other.GetComponent<PlayerInventory>().medkitAmount += Amount;
        }

        if (redKeycard)
        {
            other.GetComponent<PlayerInventory>().redKeycard = true;
        }
        if (blueKeycard)
        {
            other.GetComponent<PlayerInventory>().blueKeycard = true;
        }
        if (yellowKeycard)
        {
            other.GetComponent<PlayerInventory>().yellowKeycard = true;
        }
    }
}

