using UnityEngine;
using System.Collections;

public class MagazineWeapon : Weapon
{
    public AudioSource reload;

     public void ini()
    {
        reload = GameObject.Find("ReloadSound").GetComponent<AudioSource>();
    }
    public virtual void MagReload(ref int Magazine, ref int currentAmmo, int MaxAmmo, int ReloadTime)
    {
        if (Input.GetButtonDown("Reload"))
        {
            ini();
            reload.Play();
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
