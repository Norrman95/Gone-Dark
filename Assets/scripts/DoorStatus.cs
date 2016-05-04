using UnityEngine;
using System.Collections;

public class DoorStatus : MonoBehaviour 
{
    public DoorScript[] Door = new DoorScript[1];

    void Start()
    {
        Door[0] = GameObject.Find("Door").GetComponent<DoorScript>();
    }

    void Update()
    {
        for (int i = 0; i < Door.Length; i++)
        {
            if (Door[i].Open)
            {
                Door[i].gameObject.SetActive(false);
            }
            else
            {
                Door[i].gameObject.SetActive(true);
            }
        }
    }
}
