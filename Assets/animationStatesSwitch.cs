using UnityEngine;
using System.Collections;

public class animationStatesSwitch : MonoBehaviour {
    public Animator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {

        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dir = Input.mousePosition - pos;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Debug.Log(angle);

        while (angle < 110 && angle > 80)
        {
            anim.Play("Back");
            break;
        }

        while (angle < 80 && angle > 30)
        {
            anim.Play("Halv-Side");
            break;
        }

        while (angle < 30 && angle > 0)
        {
            anim.Play("Side");
            break;
        }

        while (angle < 0 && angle > -25)
        {
            anim.Play("Halv-Front");
            break;
        }

        while (angle < -25 && angle > -110)
        {
            anim.Play("Front");
            break;
        }

        while (angle < -110 && angle > -140)
        {
            anim.Play("Flipped Halv-Front");
            break;
        }

        while (angle < -140 && angle > -170)
        {
            anim.Play("Flipped Side");
            break;
        }

        while (angle < 170 && angle > 110)
        {
            anim.Play("Flipped Halv-Side");
            break;
        }


	}
}
