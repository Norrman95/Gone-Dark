using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

    private GameObject mousechecker;
    private GameObject player;
	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(gameObject);
        mousechecker = GameObject.Find("RayCube");
        player = GameObject.Find("Player");
    }
	
	// Update is called once per frame
	void Update () 
    {
        
        Vector3 playerInfo = player.transform.position;
        mousechecker.transform.position = playerInfo;
	
	}
}
