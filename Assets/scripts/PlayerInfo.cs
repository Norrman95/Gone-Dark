using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour
{

    public int currentHP;
    private int maxHP = 50;

    void Start()
    {

    }

    void Update()
    {
        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }

    public void AdjustHP(int newHP)
    {
        currentHP += newHP;
        print(currentHP);
    }

}
