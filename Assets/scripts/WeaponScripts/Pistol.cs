using UnityEngine;
using System.Collections;

public class Pistol : MagazineWeapon
{
    public GameObject shot;

    void Update()
    {
        MagReload(ref GetComponent<PlayerInventory>().pistolMag, ref GetComponent<PlayerInventory>().currentpistolAmmo, 8, 5);
        Fire(shot, GetComponent<PlayerInventory>().pistol, ref GetComponent<PlayerInventory>().currentpistolAmmo, 0.25f, 1, 0);
    }
}
