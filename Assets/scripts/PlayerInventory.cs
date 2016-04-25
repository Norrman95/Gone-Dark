using UnityEngine;
using System.Collections;

public class PlayerInventory : MonoBehaviour
{
    public bool pistol, shotgun, axe;
    public int pistolMag, totalShells;
    public int currentpistolAmmo, currentShells;
    public bool carriesPistol, carriesShotgun, carriesAxe;
    public int medkitAmount;

    void Start()
    {

    }

    void Update()
    {
        Swapweapons();
    }


    void Swapweapons()
    {
        if (Input.GetButton("pistol"))
        {
            pistol = true;
            shotgun = false;
            axe = false;
        }

        if (Input.GetButton("shotgun"))
        {
            pistol = false;
            shotgun = true;
            axe = false;
        }
        if (Input.GetButton("Axe"))
        {
            pistol = false;
            shotgun = false;
            axe = true;
        }
    }
}
