using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using UnityEngine.SceneManagement;


[Serializable]

public class PlayerInventory : MonoBehaviour
{
    public bool pistol, shotgun, axe;
    public bool carriesShotgun, carriesAxe;
    
    public int pistolMag, totalShells;
    public int currentpistolAmmo, currentShells;
    public int medkitAmount;

    void Start()
    {

    }

    void Update()
    {
        Swapweapons();

        if (Input.GetKey(KeyCode.L))
        {

            LoadInventory();
        }
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
        if (Input.GetButton("axe"))
        {
            pistol = false;
            shotgun = false;
            axe = true;
        } 
    }

    public void SaveInventory()
    {
        PlayerPrefs.SetInt("pistolMag", pistolMag);
        PlayerPrefs.SetInt("totalShells", totalShells);
        PlayerPrefs.SetInt("currentpistolAmmo", currentpistolAmmo);
        PlayerPrefs.SetInt("currentShells", currentShells);
        PlayerPrefs.SetInt("medkitAmount", medkitAmount);
        PlayerPrefs.SetInt("carriesShotgun", (carriesShotgun ? 1 : 0));
        PlayerPrefs.SetInt("carriesAxe", (carriesAxe ? 1 : 0));
        PlayerPrefs.SetInt("pistol", (pistol ? 1 : 0));
        PlayerPrefs.SetInt("shotgun", (shotgun ? 1 : 0));
        PlayerPrefs.SetInt("axe", (axe ? 1 : 0));
    }
    public void LoadInventory()
    {
        pistolMag = PlayerPrefs.GetInt("pistolMag");
        totalShells = PlayerPrefs.GetInt("totalShells");
        currentpistolAmmo = PlayerPrefs.GetInt("currentpistolAmmo");
        currentShells = PlayerPrefs.GetInt("currentShells");
        medkitAmount = PlayerPrefs.GetInt("medkitAmount");
        axe = (PlayerPrefs.GetInt("axe") != 0);
        shotgun = (PlayerPrefs.GetInt("shotgun") != 0);
        pistol = (PlayerPrefs.GetInt("pistol") != 0);
        carriesAxe = (PlayerPrefs.GetInt("carriesAxe") != 0);
        carriesShotgun = (PlayerPrefs.GetInt("carriesShotgun") != 0);
    }
}
