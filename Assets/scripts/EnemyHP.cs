using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour 
{
    public int currentHp;

    public void AdjustHealth(int newHp)
    {
        currentHp += newHp;
        
    }
}
