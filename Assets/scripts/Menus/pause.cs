using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public bool canpause;
    private GameObject raycube;
    public PlayerStats save;
    public PlayerInventory savInv;
    public animationStatesSwitch rotation;
    rotation getMouse;
    FollowPlayer checkRaycube;
    MainMenu hasStarted;
    DoorFunction[] Door = new DoorFunction[4];
    ItemPickup[] Item = new ItemPickup[2];
    EnemyStats[] Enemy = new EnemyStats[7];

    //public int sceneID;
    //Scene GetScene;

    //public Scene Scene
    //{

    //    get
    //    {
    //        return GetScene;
    //    }

    //    set
    //    {
    //        GetScene = value;
    //    }

    //    sceneID = SceneManager.GetActiveScene().buildIndex;
    //    PlayerPrefs.SetInt("sceneID", sceneID);
    //    sceneID = PlayerPrefs.GetInt("sceneID");
    //}

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
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name != "Main Menu")
        {
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
                
            }
        }

        if (hasStarted.started)
        {
            Time.timeScale = 1;
            canpause = true;
            rotation.pistolDown = true;
            getMouse.enabled = true;
           
        }
        hasStarted.started = false;
    }

    void OnGUI()
    {
        if (!canpause && SceneManager.GetActiveScene().name != "Main Menu")
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 25, 250, 50), "Resume"))
            {
                Time.timeScale = 1;
                canpause = true;
                getMouse.enabled = true;
                


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
                hasStarted.gameObject.SetActive(true);
                hasStarted.started = false;
            }
        }
    }
}
