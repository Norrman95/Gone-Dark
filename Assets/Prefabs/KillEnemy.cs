using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour
{
    public int Damage;

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyStats>().AdjustHealth(-Damage);
        }
    }
}
