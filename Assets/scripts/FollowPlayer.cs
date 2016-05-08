using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    private GameObject mousechecker;
    private GameObject player;
	// Use this for initialization
	void Start () 
    {
        mousechecker = GameObject.Find("RayCube");
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () 
    {
        DontDestroyOnLoad(gameObject);
        Vector3 playerInfo = player.transform.position;
        mousechecker.transform.position = playerInfo;
	
	}
}
