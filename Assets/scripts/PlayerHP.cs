using UnityEngine;
using System.Collections;

public class PlayerHP : MonoBehaviour
{

    public int currentHP, maxHP;
    

    public void Start()
    {
        currentHP = maxHP;
    }

    public void AdjustHP(int newHP)
    {
        currentHP += newHP;
        print(currentHP);

    }

    void Update()
    {
        if(currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
