using UnityEngine;
using System.Collections;

public class walkingSound : MonoBehaviour {

        public bool isWalking = false;
        public AudioSource sound;
    
	// Use this for initialization
	void Start () {

        //sound.Play();

     
	}
	
	// Update is called once per frame
	void Update () {
       

        sound.GetComponent<AudioSource>().Pause();
        if (Input.GetKey("w") || Input.GetKey("d") || Input.GetKey("s") || Input.GetKey("a"))
            {
            isWalking = true;
        }
        else
        {
            isWalking = false;
        }

        if (isWalking == true)
        {

            sound.UnPause();
        }

        if (isWalking == false)
        {
            sound.Pause();
        }

    }
}
