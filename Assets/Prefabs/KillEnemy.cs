using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour
{
    public int Damage;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHP>().AdjustHealth(-Damage);

            if (other.gameObject.GetComponent<EnemyHP>().currentHp <= 0)
            {
                DestroyObject(other.gameObject);

                print("enemy killed");
            }
        }
    }
}
