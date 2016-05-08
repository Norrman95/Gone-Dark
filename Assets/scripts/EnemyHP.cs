using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour 
{
    public int currentHp;
    public bool Killed;

    public void Update()
    {
        KillEnemy();
    }

    public void saveEnemystatus(int i)
    {
        PlayerPrefs.SetInt("currentHp"+ i, currentHp);
    }

    public void loadEnemystatus(int i)
    {
        currentHp = (PlayerPrefs.GetInt("currentHp"+ i));
    }

    public void AdjustHealth(int newHp)
    {
        currentHp += newHp;
    }

    public void KillEnemy()
    {
        if (currentHp <= 0)
        {
            Killed = true;
        }
    }
}
