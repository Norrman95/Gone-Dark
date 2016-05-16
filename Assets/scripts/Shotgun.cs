using UnityEngine;
using System.Collections;

public class Shotgun : Weapon
{
    public GameObject shot;

	void Start ()
    {
        base.Start(shot, 9, 0);
	}

	void Update () 
    {
        ShellReload(ref GetComponent<PlayerInventory>().totalShells, ref GetComponent<PlayerInventory>().currentShells, 5);
        Fire(ref GetComponent<PlayerInventory>().currentShells, 15);
        AvailableAction(GetComponent<PlayerInventory>().shotgun, GetComponent<PlayerInventory>().currentShells);
	}

    public void ShellReload(ref int totalShells, ref int currentShells, int ReloadTime)
    {
        int maxShells = 2;
        int addedShells = maxShells - currentShells;
        
        if (Input.GetButtonDown("Reload"))
        {
            if (totalShells >= 1 && currentShells != maxShells)
            {
                Reload(ReloadTime);
            }
        }
        if (reloaded)
        {
            if(totalShells > 1)
            {
                totalShells -= addedShells;
                currentShells += addedShells;
            }
            else
            {
                totalShells = 0;
                currentShells += 1;
            }

            reloaded = false;
        }
    }
}
