using UnityEngine;
using System.Collections;

public class Pistol : MagazineWeapon
{
    public GameObject shot;
    int currentAmmo, currentMags, projectileAmount;

    void Start()
    {
        base.Start(shot, 1, 0.25f);
    }

    void Update()
    {
        MagReload(ref GetComponent<PlayerInventory>().pistolMag, ref GetComponent<PlayerInventory>().currentpistolAmmo, 8, 5);
        Fire(ref GetComponent<PlayerInventory>().currentpistolAmmo, 0);
        AvailableAction(GetComponent<PlayerInventory>().pistol, GetComponent<PlayerInventory>().currentpistolAmmo);
    }
}
