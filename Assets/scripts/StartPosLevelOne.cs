﻿using UnityEngine;
using System.Collections;

public class StartPosLevelOne : MonoBehaviour {

    Vector3 startPos;
	
	void Start () {

        startPos = new Vector3(0, 0, 0);
        GameObject.Find("Player").transform.position = startPos;

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
