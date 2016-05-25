using UnityEngine;
using System.Collections;

public class walksoundscript : MonoBehaviour {
    bool walkPlay;
	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("w") || Input.GetKey("d") || Input.GetKey("s") || Input.GetKey("a"))
        {
            walkPlay = true;
        }
        else
        walkPlay = false;

        if (walkPlay == true)
        {
            GetComponent<AudioSource>().UnPause();
            
           
        }
        if (walkPlay == false)
        {   
            GetComponent<AudioSource>().Pause();

        }




    }
}
