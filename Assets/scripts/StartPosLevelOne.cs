using UnityEngine;
using System.Collections;

public class StartPosLevelOne : MonoBehaviour {

    Vector3 startPos;
	
	void Start () {

        startPos = new Vector3(550, -10, -3.1f);
        GameObject.Find("Player").transform.position = startPos;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
