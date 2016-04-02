using UnityEngine;
using System.Collections;

public class EnemyHP : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    public int currentHp = 50;

    public void AdjustHealth(int newHp)
    {
        currentHp += newHp;
        print(currentHp);
    }
	
	// Update is called once per frame
	void Update () {





	
	}
}
