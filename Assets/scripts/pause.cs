using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour
{
    bool canpause;
    private GameObject raycube;
    private Animator animate;
    private GUIContent content;
    public PlayerInfo save;
    public PlayerInventory savInv;

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

        savInv = GameObject.Find("Player").GetComponent<PlayerInventory>();
        save = GameObject.Find("Player").GetComponent<PlayerInfo>();
        canpause = true;
        raycube = GameObject.Find("RayCube");
        animate = GameObject.Find("walkSpritesheet_0").GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (canpause)
            {
                Time.timeScale = 0;
                canpause = false;
                raycube.SetActive(false);
                animate.enabled = false;
                
            }
            else
            {
                Time.timeScale = 1;
                canpause = true;
                raycube.SetActive(true);
                animate.enabled = true;
            }
        }
    }

    void OnGUI()
    {
        if (!canpause)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 250, 50), "Resume"))
            {
                Time.timeScale = 1;
                canpause = true;
                raycube.SetActive(true);
                animate.enabled = true;

            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 75, 250, 50), "Save Game"))
            {
                for (int i = 0; i < Item.Length; i++)
                {
                    Item[i].saveItemstatus();
                }
                for (int i = 0; i < Door.Length; i++)
                {
                    Door[i].saveDoorstatus();
                }
                for (int i = 0; i < Enemy.Length; i++)
                {
                    Enemy[i].saveEnemystatus();
                }
                save.SaveInfo();
                savInv.SaveInventory();
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 125, 250, 50), "Exit Game"))
            {
                Application.Quit();
            }

        }
    }













}
