using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour {

    private GameObject mousechecker;
    private GameObject player;
    private pause checkpause;
    
    // Use this for initialization
    public void Awake()
    {
        DontDestroyOnLoad(this);
        if(Resources.FindObjectsOfTypeAll(GetType()).Length > 2)
        {
            Destroy(gameObject);
        }
       

        //if (FindObjectsOfType(GetType()).Length > 1)
        //{
        //    Destroy(gameObject);
        //}
    }


    void Start () 
    {
        
     
        mousechecker = GameObject.Find("RayCube");
        player = GameObject.Find("Player");
        checkpause = GameObject.Find("PauseObject").GetComponent<pause>();
    }
	
	// Update is called once per frame
	void Update () 
    {
            Vector3 playerInfo = player.transform.position;
        mousechecker.transform.position = playerInfo;
	
	}
}
