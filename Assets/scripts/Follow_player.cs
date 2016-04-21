using UnityEngine;
using System.Collections;

public class Follow_player : MonoBehaviour {
    private GameObject player;
    private GameObject Plane;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
        Plane = GameObject.Find("RaycastCube");
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 playerInfo = player.transform.position;
        Vector3 planeInfo = Plane.transform.position;
        planeInfo.x = 10;
        planeInfo.y = playerInfo.y + 10;
        planeInfo.z = playerInfo.z;
        //new Vector3(playerInfo.x, playerInfo.y, playerInfo.z);
    }
}
