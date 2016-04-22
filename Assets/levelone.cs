using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class levelone : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("Level 1");
        }



    }
}
