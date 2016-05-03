using UnityEngine;
using System.Collections;

public class StartPosBlockScene : MonoBehaviour {

    Vector3 startPos;
	void Start () {

        startPos = new Vector3(60, 0, -65);
        GameObject.Find("Player").transform.position = startPos;
	
	}
	
	
	void Update () {
	
	}
}
