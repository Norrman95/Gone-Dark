using UnityEngine;
using System.Collections;

public class Alarm : MonoBehaviour 
{
    
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            
        }
    }
}
