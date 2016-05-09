using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EntityStatus : MonoBehaviour
{
    DoorScript[] Door = new DoorScript[3];
    ItemPickup[] Item = new ItemPickup[11];
    EnemyHP[] Enemy = new EnemyHP[7];

    void Start()
    {
        Item[0] = GameObject.Find("BlueCard").GetComponent<ItemPickup>();
        Item[1] = GameObject.Find("RedCard").GetComponent<ItemPickup>();
        Item[2] = GameObject.Find("YellowCard").GetComponent<ItemPickup>();
        Item[3] = GameObject.Find("PistolMag1").GetComponent<ItemPickup>();
        Item[4] = GameObject.Find("PistolMag2").GetComponent<ItemPickup>();
        Item[5] = GameObject.Find("MedKit1").GetComponent<ItemPickup>();
        Item[6] = GameObject.Find("ShotgunAmmo1").GetComponent<ItemPickup>();
        Item[7] = GameObject.Find("MedKit2").GetComponent<ItemPickup>();
        Item[8] = GameObject.Find("ShotgunAmmo2").GetComponent<ItemPickup>();
        Item[9] = GameObject.Find("PistolMag3").GetComponent<ItemPickup>();
        Item[10] = GameObject.Find("ShotGun").GetComponent<ItemPickup>();

        Door[0] = GameObject.Find("RedDoor").GetComponent<DoorScript>();
        Door[1] = GameObject.Find("BlueDoor").GetComponent<DoorScript>();
        Door[2] = GameObject.Find("YellowDoor").GetComponent<DoorScript>();

        Enemy[0] = GameObject.Find("Enemy").GetComponent<EnemyHP>();
        Enemy[1] = GameObject.Find("Enemy (1)").GetComponent<EnemyHP>();
        Enemy[2] = GameObject.Find("Enemy (2)").GetComponent<EnemyHP>();
        Enemy[3] = GameObject.Find("Enemy (3)").GetComponent<EnemyHP>();
        Enemy[4] = GameObject.Find("Enemy (4)").GetComponent<EnemyHP>();
        Enemy[5] = GameObject.Find("Enemy (5)").GetComponent<EnemyHP>();
        Enemy[6] = GameObject.Find("Enemy (6)").GetComponent<EnemyHP>();
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
