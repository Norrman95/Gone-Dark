using UnityEngine;
using System.Collections;

public class EntityStatus : MonoBehaviour
{
    DoorScript[] Door = new DoorScript[1];
    ItemPickup[] Item = new ItemPickup[2];
    EnemyHP[] Enemy = new EnemyHP[3];

    void Start()
    {
        Item[0] = GameObject.Find("Item").GetComponent<ItemPickup>();
        Item[1] = GameObject.Find("Item1").GetComponent<ItemPickup>();

        Door[0] = GameObject.Find("Door").GetComponent<DoorScript>();

        Enemy[0] = GameObject.Find("Enemy").GetComponent<EnemyHP>();
        Enemy[1] = GameObject.Find("Enemy1").GetComponent<EnemyHP>();
        Enemy[2] = GameObject.Find("Enemy Alarm").GetComponent<EnemyHP>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            for (int i = 0; i < Item.Length; i++)
            {
                Item[i].loadItemstatus(i);
            }
            for (int i = 0; i < Door.Length; i++)
            {
                Door[i].loadDoorstatus(i);
            }
            for (int i = 0; i < Enemy.Length; i++)
            {
                Enemy[i].loadEnemystatus(i);
            }
        }

        for (int i = 0; i < Item.Length; i++)
        {
            if (Item[i].pickedUp)
            {
                Item[i].gameObject.SetActive(false);
            }
            else
            {
                Item[i].gameObject.SetActive(true);
            }
        }

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

        for (int i = 0; i < Enemy.Length; i++)
        {
            if (Enemy[i].Killed)
            {
                Enemy[i].gameObject.SetActive(false);
            }
            else
            {
                Enemy[i].gameObject.SetActive(true);
            }
        } 
    }
}
