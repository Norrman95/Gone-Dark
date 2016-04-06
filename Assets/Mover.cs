using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

    private Rigidbody rb;
    public float speed;

	void Start()
    {
<<<<<<< HEAD
        Cursor.visible = true;
=======
        //Cursor.visible = false;
>>>>>>> origin/master

        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward *speed;
    }
	
}
