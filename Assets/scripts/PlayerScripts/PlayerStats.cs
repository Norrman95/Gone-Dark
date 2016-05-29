using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public class PlayerStats : MonoBehaviour
{
    public int currentHP, currentStamina;
    private int maxHP = 50;
    private int maxStamina = 200;
    public bool running = false;
    public float positionX, positionY, positionZ;

    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadInfo();
        }

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        if (currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }

        if (running)
        {
            currentStamina -= 1;
        }
        if (!running && currentStamina <= maxStamina)
        {
            currentStamina += 1;
        }
    }

    public void AdjustHP(int newHP)
    {
        currentHP += newHP;
        print(currentHP);
    }

    public void SaveInfo()
    {
        PlayerPrefs.SetFloat("positionX", transform.position.x);
        PlayerPrefs.SetFloat("positionY", transform.position.y);
        PlayerPrefs.SetFloat("positionZ", transform.position.z);
        PlayerPrefs.SetInt("currentHP", currentHP);
        PlayerPrefs.SetInt("currentStamina", currentStamina);
        PlayerPrefs.Save();
    }

    public void LoadInfo()
    {
        currentHP = PlayerPrefs.GetInt("currentHP");
        currentStamina = PlayerPrefs.GetInt("currentStamina");
        positionX = PlayerPrefs.GetFloat("positionX");
        positionY = PlayerPrefs.GetFloat("positionY");
        positionZ = PlayerPrefs.GetFloat("positionZ");
        transform.position = new Vector3(positionX, positionY, positionZ);
    }
}
