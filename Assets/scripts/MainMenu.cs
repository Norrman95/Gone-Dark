using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    private bool firstMenu = true;
    private bool levelSelectMenu = false;
    private bool optionsMenu = false;
    private PlayerInventory loadInv;
    private PlayerInfo loadInfo;
    Vector3 StartPos;
    public Texture texBox;
    GUIContent content;
    public float ingameVolume = 0.0f;




    void Start()
    {
        loadInv = GameObject.Find("Player").GetComponent<PlayerInventory>();
        loadInfo = GameObject.Find("Player").GetComponent<PlayerInfo>();
        content = new GUIContent("", texBox, "");


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

                //  SceneManager.LoadScene("block scenes");
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
            ingameVolume = AudioListener.volume;
            ingameVolume = GUI.HorizontalSlider(new Rect(875, 100, 100, 50), ingameVolume, 0.0f, 10.0f);

            if (GUI.Button(new Rect(875, 800, 150, 25), "Back"))
            {
                optionsMenu = false;
                firstMenu = true;
            }
        }

    }

}
