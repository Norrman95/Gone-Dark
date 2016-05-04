using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour
{
    public int Damage;
    public int checkDead;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {

            LoadEnemy();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {

            saveEnemy();
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHP>().AdjustHealth(-Damage);

            if (other.gameObject.GetComponent<EnemyHP>().currentHp <= 0)
            {
               // DestroyObject(other.gameObject);
                other.gameObject.SetActive(false);
                checkDead = 1;


                print("enemy killed");
            }
            else checkDead = 0;


        }
    }
   public void saveEnemy()
    {
        PlayerPrefs.SetInt("checkDead", checkDead);
    }
   public void LoadEnemy()
    {
        //PlayerPrefs.GetInt("Enemy", checkDead);
        checkDead = PlayerPrefs.GetInt("checkDead");
        if (checkDead == 1)
        {
            gameObject.SetActive(false);
        }
        else gameObject.SetActive(true);

    }

}
