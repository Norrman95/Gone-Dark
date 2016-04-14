using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToLevelOne : MonoBehaviour
{


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {  
            SceneManager.LoadScene("block scenes");
        }



    }
}
