using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;

[Serializable]

public class SaveLoadGame : MonoBehaviour
{
    public int savedPistolAmmo;
    public int savedShotGunAmmo;
    private int loadedPistolAmmo;
    private int loadedSotgunAmmo;
    public Vector3 savedPosition;
    private Vector3 loadedPosition;
    private PlayerControls newData;
    

    void Start()
    {

        
    }

   


    void Update()
    {
        newData = gameObject.GetComponent<PlayerControls>();
       
        
    }




    public void Save()
    {
       

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/SavedGame.dat", FileMode.Create);
        savedPistolAmmo = newData.currentpistolAmmo;
        savedShotGunAmmo = newData.currentshotgunAmmo;    
        savedPosition = newData.transform.position;
        bf.Serialize(file, newData);
        file.Close();
    }

    

    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/SavedGame.dat"))
        {
            Debug.Log("YAS");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SavedGame.dat", FileMode.Open);
            PlayerControls newData = (PlayerControls)bf.Deserialize(file);
            file.Close();
            loadedPistolAmmo = newData.currentpistolAmmo;
            loadedSotgunAmmo = newData.currentshotgunAmmo;
            savedPosition = newData.transform.position;

        }
    }





}

