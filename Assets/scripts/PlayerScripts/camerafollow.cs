﻿using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour {
    public float height = 10;
    private Camera mainCamera;
    public GameObject player;
	// Use this for initialization
	void Start () {
        mainCamera = GetComponent<Camera>();
        player = GameObject.Find("Player");
      //  DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerInfo = player.transform.position;
        //mainCamera.transform.position = new Vector3(playerInfo.x+15, 30.3f + playerInfo.y, playerInfo.z-7);
        mainCamera.transform.position = new Vector3(playerInfo.x + 5,playerInfo.y + 10, playerInfo.z);
	}
}
