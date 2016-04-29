using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Loadposition : MonoBehaviour
{

    private Vector3 startPos;
    void Start()
    {


    }
    void Update()
    {
        GameObject.Find("Player").transform.position = startPos;
        if (SceneManager.GetActiveScene().name == "block scenes")
        {

            startPos = new Vector3(71, 0, -74);

        }
        if (SceneManager.GetActiveScene().name == "level 1")
        {

            startPos = new Vector3(500, -25, 0);

        }

        if (SceneManager.GetActiveScene().name == "intro level")
        {

            startPos = new Vector3(10004, 190, -49);

        }
    }
}
