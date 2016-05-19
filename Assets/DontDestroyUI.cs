using UnityEngine;
using System.Collections;

public class DontDestroyUI : MonoBehaviour {


	void Start () {
	
	}

    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }


   
    void Update () {
	
	}
}
