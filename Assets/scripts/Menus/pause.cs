using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    bool dead = false;
    public bool paused = false;
    bool ready = false;
    public bool canpause;
    private GameObject raycube;
    public PlayerStats save;
    public PlayerInventory savInv;
    public animationStatesSwitch rotation;
    rotation getMouse;
    FollowPlayer checkRaycube;
    MainMenu hasStarted;
    DoorFunction[] Door = new DoorFunction[4];
    ItemPickup[] Item = new ItemPickup[8];
    EnemyStats[] Enemy = new EnemyStats[8];
    KillPlayer[] getdeath = new KillPlayer[7];

    void OnLevelWasLoaded(int level)
    {
        if (level == 2)
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



            for (int i = 0; i < getdeath.Length; i++)
            {
                string ConvertedString = i.ToString();
                getdeath[i] = GameObject.Find("Enemy (" + ConvertedString + ")").GetComponent<KillPlayer>();

                if (getdeath[i].dead)
                {
                    Time.timeScale = 0;
                    canpause = false;
                    getMouse.enabled = false;
                    dead = true;
                    paused = true;
                }
                
            }


        }
    }






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
        hasStarted = GameObject.Find("Canvas").gameObject.GetComponent<MainMenu>();
        raycube = GameObject.FindWithTag("RaycastCube");
        checkRaycube = GameObject.Find("RayCube").gameObject.GetComponent<FollowPlayer>();
        savInv = GameObject.Find("Player").GetComponent<PlayerInventory>();
        save = GameObject.Find("Player").GetComponent<PlayerStats>();
        rotation = GameObject.Find("Player/walkSpritesheet_0").GetComponent<animationStatesSwitch>();
        canpause = true;
        getMouse = GameObject.Find("Player/Rotation").GetComponent<rotation>();


    }

    void Update()
    {

     

        if (dead && SceneManager.GetActiveScene().name == "Main Menu")
        {
            Time.timeScale = 1;
            canpause = true;
            rotation.pistolDown = true;
            getMouse.enabled = true;
            paused = false;
            dead = false;
        }

        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Main Menu" && !dead)
        {
            paused = true;
            if (canpause)
            {
                Time.timeScale = 0;
                canpause = false;
                getMouse.enabled = false;
            }
            else
            {
                Time.timeScale = 1;
                canpause = true;
                getMouse.enabled = true;
                paused = false;

            }
        }


        if (hasStarted.started)
        {
            Time.timeScale = 1;
            canpause = true;
            rotation.pistolDown = true;
            getMouse.enabled = true;
            paused = false;

        }
        hasStarted.started = false;
    }


    void OnGUI()
    {
        if (!canpause && SceneManager.GetActiveScene().name != "Main Menu" && !dead)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 250, 50), "Resume"))
            {
                Time.timeScale = 1;
                canpause = true;
                getMouse.enabled = true;
                paused = false;



            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 75, 250, 50), "Save Game"))
            {

                save.SaveInfo();
                savInv.SaveInventory();
                for (int i = 0; i < Enemy.Length; i++)
                {
                    Enemy[i].saveEnemystatus(i);
                }

                for (int i = 0; i < Item.Length; i++)
                {
                    Item[i].saveItemstatus(i);
                }
                for (int i = 0; i < Door.Length; i++)
                {
                    Door[i].saveDoorstatus(i);
                }




            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 125, 250, 50), "Exit Game To Desktop"))
            {
                Application.Quit();
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 175, 250, 50), "Exit Game To Main Menu"))
            {
                SceneManager.LoadScene("Main Menu");
                hasStarted.gameObject.SetActive(true);
                hasStarted.started = false;
            }
        }
    }
}
