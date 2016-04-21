using UnityEngine;
using System.Collections;

public class Killbullet : MonoBehaviour {

    

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "bullet")
        {

            DestroyObject(other.gameObject);

            print("bullet removed");
        }
    }
}
