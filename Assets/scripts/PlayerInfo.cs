using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;


[Serializable]
public class PlayerInfo : MonoBehaviour
{

    public int currentHP, currentStamina;
    private int maxHP = 50;
    private int maxStamina = 200;
    public bool running = false;

    void Start()
    {
        Debug.Log(currentStamina);
    }

    void Update()
    {
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        if(currentStamina > maxStamina)
        {
            currentStamina = maxStamina;
        }

        if(running)
        {
            currentStamina -= 1;
        }
        if(!running && currentStamina <= maxStamina)
        {
            currentStamina += 1;
        }
    }

    public void AdjustHP(int newHP)
    {
        currentHP += newHP;
        print(currentHP);
    }
}
