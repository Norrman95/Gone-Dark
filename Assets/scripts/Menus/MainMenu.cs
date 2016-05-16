using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    GUIContent content;
    GUIContent content2;
    GUIContent content3;
    GUIContent content4;
    public Texture texboxControlmap;
    public Texture texboxVolume;
    public Texture texboxControls;
    private pause getpause;
    public bool started;
    UIscript image;
    private bool firstMenu = true;
    private bool levelSelectMenu = false;
    private bool optionsMenu = false;
    private PlayerInventory loadInv;
    private PlayerInfo loadInfo;
    Vector3 StartPos;
    public Texture texBox;
    public float ingameVolume = 0.0f;




    void Start()
    {
       
        loadInv = GameObject.Find("Player").GetComponent<PlayerInventory>();
        loadInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        content = new GUIContent("", texBox, "");
        content2 = new GUIContent("", texboxVolume, "Change the volume");
        content3 = new GUIContent("", texboxControls, "The standard controls");
        content4 = new GUIContent("", texboxControlmap, "");
        image = GameObject.Find("InventoryScreen").GetComponent<UIscript>();

    }


    void Update()
    {
        GameObject.Find("Player").transform.position = StartPos;

    }




    void OnGUI()
    {
        FirstMenu();
        Options();

    }


    void FirstMenu()
    {
        if (firstMenu && optionsMenu != true)
        {
            if (GUI.Button(new Rect(875, Screen.height / 2 - 120, 150, 25), "New Game"))
            {
               
                SceneManager.LoadScene("intro scene");


            }

            if (GUI.Button(new Rect(875, Screen.height / 2 - 75, 150, 25), "Load Game"))
            {
                loadInfo.LoadInfo();
                loadInv.LoadInventory();

            }

            if (GUI.Button(new Rect(875, Screen.height / 2 - 50, 150, 25), "Settings"))
            {
                optionsMenu = true;
                firstMenu = false;

            }

            if (GUI.Button(new Rect(875, Screen.height / 2 - 25, 150, 25), "Quit Game"))
            {
                Application.Quit();
            }


        }
    }


    void Options()
    {
        if (optionsMenu)
        {

            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), content);
            GUI.Box(new Rect(500, 100, content2.image.width, content2.image.height), content2);
            GUI.Box(new Rect(1200, 100, content2.image.width, content2.image.height), content3);
            GUI.Box(new Rect(825, 175, content4.image.width, content4.image.height), content4);
            ingameVolume = AudioListener.volume;
            ingameVolume = GUI.HorizontalSlider(new Rect(500, 175, 100, 50), ingameVolume, 0.0f, 10.0f);

            if (GUI.Button(new Rect(875, 800, 150, 25), "Back"))
            {
                optionsMenu = false;
                firstMenu = true;
            }
        }
    }

}
