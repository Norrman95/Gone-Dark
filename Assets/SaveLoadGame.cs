using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using UnityEngine.SceneManagement;

[Serializable]

public class SaveLoadGame : MonoBehaviour
{
    public int savedPistolAmmo;
    public int savedShotGunAmmo;
    private int loadedPistolAmmo;
    private int loadedSotgunAmmo;
    public Vector3 savedPosition;
    private Vector3 loadedPosition;
    private PlayerInventory newData;
    public string savedScene;
    public string loadedScene;
    public string activeScene;


    void Start()
    {


    }
    public void getscene()
    {
        activeScene = SceneManager.GetActiveScene().name;
    }



    void Update()
    {
        newData = gameObject.GetComponent<PlayerInventory>();

        getscene();
        if (Input.GetKey(KeyCode.L))
        {
            Load();


        }

    }


    public void Save()
    {


        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/SavedGame.dat", FileMode.Create);
        savedPistolAmmo = newData.currentpistolAmmo;
        savedShotGunAmmo = newData.currentShells;
        savedPosition = newData.transform.position;
        savedScene = activeScene;
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
            PlayerInventory newData = (PlayerInventory)bf.Deserialize(file);
            file.Close();
            activeScene = savedScene;
            SceneManager.LoadScene(savedScene);
            loadedPistolAmmo = newData.currentpistolAmmo;
            loadedSotgunAmmo = newData.currentShells;
            savedPosition = newData.transform.position;


        }
    }





}

