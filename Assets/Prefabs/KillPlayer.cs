using UnityEngine;
using System.Collections;

public class KillPlayer : MonoBehaviour {

    private float nextHit;
    public float Hitrate;
	
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && Time.time > nextHit)
        {
            
            
        nextHit = Time.time + Hitrate;
            
           
            other.gameObject.GetComponent<PlayerHP>().AdjustHP(-10);

            if (other.gameObject.GetComponent<PlayerHP>().currentHP <= 0)
            {
                DestroyObject(other.gameObject);
            }





        }
    }



}
