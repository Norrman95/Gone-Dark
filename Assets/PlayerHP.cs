using UnityEngine;
using System.Collections;

public class PlayerHP : MonoBehaviour
{

    public int currentHP;



    public void AdjustHP(int newHP)
    {
        currentHP += newHP;
        print(currentHP);

    }

    void Update()
    {
        
    }
}
