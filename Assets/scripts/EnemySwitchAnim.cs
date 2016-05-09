using UnityEngine;
using System.Collections;

public class EnemySwitchAnim : MonoBehaviour {

    // Use this for initialization
    public Animator anim;
    public GameObject EnemyInfo;
    public Transform target;
    public bool movement;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        EnemyInfo = GameObject.Find("AICharacterControl");
        
    }

    // Update is called once per frame
    void Update()
    {


        Vector3 startVec = transform.position;
        Vector3 startVecFwd = transform.forward;

        Vector3 rayDirection = target.transform.position - startVec;
        float angle = Mathf.Atan2(rayDirection.y, rayDirection.x) * Mathf.Rad2Deg;
        
        // Debug.Log(angle);

        if (angle < 110 && angle > 80)
        {
            anim.Play("Enemy Walk Back");


        }
        
        if (angle < 80 && angle > 30 && movement == true)
        {
            anim.Play("Enemy Walk Halv Side");

        }

        if (angle < 30 && angle > 0 )
        {
            anim.Play("Enemy Walk Side");

        }

        if (angle < 0 && angle > -25 )
        {
            anim.Play("Enemy Walk Halv Front");
        }

        
        if (angle < -25 && angle > -110 )
        {
            anim.Play("Enemy Walk Front");

        }


        if (angle < -110 && angle > -140)
        {
            anim.Play("Flipped Halv-Front");

        }
        
        if (angle < -140 && angle > -170 )
        {
            anim.Play("Flipped Side");

        }

        
        if (angle < 170 && angle > 110 )
        {
            anim.Play("Flipped Halv-Side");

        }

        


    }
}
