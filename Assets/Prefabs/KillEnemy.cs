using UnityEngine;
using System.Collections;

public class KillEnemy : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Enemy")
        {

            DestroyObject(other.gameObject);

            print("enemy killed");
        }
    }
}
