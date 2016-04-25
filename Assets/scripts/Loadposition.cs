using UnityEngine;
using System.Collections;

public class Loadposition : MonoBehaviour {

    private Vector3 startPos;

    void Start()
    {
        startPos = new Vector3(500, -25, 0);
        GameObject.Find("Player").transform.position = startPos;
    }

}
