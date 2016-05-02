using UnityEngine;
using System.Collections;

public class StartPosIntroLevel : MonoBehaviour
{

    private Vector3 startPos;
    void Start()
    {
        startPos = new Vector3(0.5f, 16, -50);
        GameObject.Find("Player").transform.position = startPos;

    }




    void Update()
    {


    }
}
