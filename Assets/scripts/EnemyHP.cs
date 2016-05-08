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

    public void saveEnemystatus()
    {
        PlayerPrefs.SetInt("Killed", (Killed ? 1 : 0));
        PlayerPrefs.SetInt("currentHp", currentHp);
    }
    public void loadEnemystatus()
    {
        currentHp = (PlayerPrefs.GetInt("currentHp"));
        Killed = (PlayerPrefs.GetInt("Killed") != 0);
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
