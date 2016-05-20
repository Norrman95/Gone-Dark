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
    public bool yellowKeycard, blueKeycard, redKeycard;
    
    public int pistolMag, totalShells;
    public int currentpistolAmmo, currentShells;
    public int medkitAmount;

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
        }

        if (Input.GetButton("shotgun"))
        {
            pistol = false;
            shotgun = true;
        }
    }

    public void SaveInventory()
    {
        PlayerPrefs.SetInt("pistolMag", pistolMag);
        PlayerPrefs.SetInt("totalShells", totalShells);
        PlayerPrefs.SetInt("currentpistolAmmo", currentpistolAmmo);
        PlayerPrefs.SetInt("currentShells", currentShells);
        PlayerPrefs.SetInt("medkitAmount", medkitAmount);
        PlayerPrefs.SetInt("yellowKeycard", (yellowKeycard ? 1 : 0));
        PlayerPrefs.SetInt("blueKeycard", (blueKeycard ? 1 : 0));
        PlayerPrefs.SetInt("redKeycard", (redKeycard ? 1 : 0));
        PlayerPrefs.SetInt("pistol", (pistol ? 1 : 0));
        PlayerPrefs.SetInt("shotgun", (shotgun ? 1 : 0));
        PlayerPrefs.Save();
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
        redKeycard = (PlayerPrefs.GetInt("redKeycard") != 0);
        blueKeycard = (PlayerPrefs.GetInt("blueKeycard") != 0);
        yellowKeycard = (PlayerPrefs.GetInt("yellowKeycard") != 0);
    }
}
