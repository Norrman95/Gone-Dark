using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EntityStatus : MonoBehaviour
{
    DoorFunction[] Door = new DoorFunction[4];
    ItemPickup[] Item = new ItemPickup[8];
    EnemyStats[] Enemy = new EnemyStats[8];

    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            string ConvertedString = i.ToString();
            Item[i] = GameObject.Find("Ammo (" + ConvertedString + ")").GetComponent<ItemPickup>();
        }
        for (int i = 5; i < 8; i++)
        {
            string ConvertedString = i.ToString();
            Item[i] = GameObject.Find("Card (" + ConvertedString + ")").GetComponent<ItemPickup>();
        }
        for (int i = 0; i < Door.Length; i++)
        {
            string ConvertedString = i.ToString();
            Door[i] = GameObject.Find("Door (" + ConvertedString + ")").GetComponent<DoorFunction>();
        }
        for (int i = 0; i < Enemy.Length; i++)
        {
            string ConvertedString = i.ToString();
            Enemy[i] = GameObject.Find("Enemy (" + ConvertedString + ")").GetComponent<EnemyStats>();            
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
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
}
