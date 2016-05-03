using UnityEngine;
using System.Collections;

public class StartPosLevelOne : MonoBehaviour {

    Vector3 startPos;
	
	void Start () {

        startPos = new Vector3(38, 2, 1.3f);
        GameObject.Find("Player").transform.position = startPos;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
