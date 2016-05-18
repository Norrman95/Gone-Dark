using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public bool canpause;
    private GameObject raycube;
    private Animator animate;
    private GUIContent content;
    public PlayerInfo save;
    public PlayerInventory savInv;
    public animationStatesSwitch rotation;
    public GameObject currentPlayer;

    private FlashlightStatus flashlight;
    private GameObject UI;
    DoorScript[] Door = new DoorScript[1];
    ItemPickup[] Item = new ItemPickup[2];
    EnemyHP[] Enemy = new EnemyHP[3];
    GameObject list;

    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }


    }


    void Start()
    {
        raycube = GameObject.FindWithTag("RaycastCube");
        Item[0] = GameObject.Find("Item").GetComponent<ItemPickup>();
        Item[1] = GameObject.Find("Item1").GetComponent<ItemPickup>();
        Door[0] = GameObject.Find("Door").GetComponent<DoorScript>();
        Enemy[0] = GameObject.Find("Enemy").GetComponent<EnemyHP>();
        Enemy[1] = GameObject.Find("Enemy1").GetComponent<EnemyHP>();
        Enemy[2] = GameObject.Find("Enemy Alarm").GetComponent<EnemyHP>();
        currentPlayer = GameObject.Find("Player");

        savInv = GameObject.Find("Player").GetComponent<PlayerInventory>();
        save = GameObject.Find("Player").GetComponent<PlayerInfo>();
        animate = GameObject.Find("walkSpritesheet_0").GetComponent<Animator>();
        rotation = GameObject.Find("Player/walkSpritesheet_0").GetComponent<animationStatesSwitch>();
        flashlight = GameObject.Find("Rotation").GetComponent<FlashlightStatus>();
        UI = GameObject.Find("InventoryScreen");
        canpause = true;




    }

    void Update()
    {




        //if (SceneManager.GetActiveScene().name == "Main Menu")
        //{
        //    canpause = true;
        //}


        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (canpause)
            {

                Time.timeScale = 0;
                canpause = false;
                raycube.SetActive(false);

                flashlight.enabled = false;
            }
            else
            {
                Time.timeScale = 1;
                canpause = true;
                raycube.SetActive(true);
                flashlight.enabled = true;


            }
        }
    }

    void OnGUI()
    {
        if (!canpause && SceneManager.GetActiveScene().name != "Main Menu")
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 250, 50), "Resume"))
            {
                Time.timeScale = 1;
                canpause = true;
                raycube.SetActive(true);


            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 75, 250, 50), "Save Game"))
            {

                save.SaveInfo();
                savInv.SaveInventory();
                for (int i = 0; i < Item.Length; i++)
                {
                    Item[i].saveItemstatus(i);
                }
                for (int i = 0; i < Door.Length; i++)
                {
                    Door[i].saveDoorstatus(i);
                }
                for (int i = 0; i < Enemy.Length; i++)
                {
                    Enemy[i].saveEnemystatus(i);
                }

            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 125, 250, 50), "Exit Game To Desktop"))
            {
                Application.Quit();
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 175, 250, 50), "Exit Game To Main Menu"))
            {

                SceneManager.LoadScene("Main Menu");
                //    DestroyObject(raycube);


            }

        }
    }













}
