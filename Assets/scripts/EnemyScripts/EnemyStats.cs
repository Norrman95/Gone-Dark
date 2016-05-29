using UnityEngine;
using System.Collections;

public class EnemyStats : MonoBehaviour 
{
    public int currentHp;
    public bool Killed;

    public void Update()
    {
        KillEnemy();
        
    }

    public void saveEnemystatus(int i)
    {
        PlayerPrefs.SetInt("currentHp" + i, currentHp);
        PlayerPrefs.SetInt("Killed" + i, (Killed ? 1 : 0));
    }

    public void loadEnemystatus(int i)
    {
        currentHp = (PlayerPrefs.GetInt("currentHp" + i));
        Killed = (PlayerPrefs.GetInt("Killed" + i) != 0);
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
