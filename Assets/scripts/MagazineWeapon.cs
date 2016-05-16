using UnityEngine;
using System.Collections;

public class MagazineWeapon : Weapon
{
    public virtual void MagReload(ref int Magazine, ref int currentAmmo, int MaxAmmo, int ReloadTime)
    {
        if (Input.GetButtonDown("Reload"))
        {
            if (Magazine >= 1 && currentAmmo != MaxAmmo)
            {
                Reload(ReloadTime);
            }
        }
        if (reloaded)
        {
            Magazine -= 1;
            currentAmmo = MaxAmmo;
            reloaded = false;
        }
    }
}
