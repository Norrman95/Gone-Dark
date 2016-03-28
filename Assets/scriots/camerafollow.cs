using UnityEngine;
using System.Collections;

public class camerafollow : MonoBehaviour {
    public float height = 10;
    private Camera mainCamera;
    private GameObject player;
	// Use this for initialization
	void Start () {
        mainCamera = GetComponent<Camera>();
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 playerInfo = player.transform.position;
        mainCamera.transform.position = new Vector3(playerInfo.x+5, height, playerInfo.z);
	
	}
}
