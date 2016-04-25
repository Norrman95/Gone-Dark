using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    private bool firstMenu = true;
    private bool levelSelectMenu = false;
    private bool optionsMenu = false;
    private SaveLoadGame loadedGame;

    void Start()
    {


    }


    void Update()
    {

    }




    void OnGUI()
    {
        FirstMenu();
        Options();
        loadedGame = gameObject.GetComponent<SaveLoadGame>();
    }


    void FirstMenu()
    {
        if (firstMenu)
        {
            if (GUI.Button(new Rect(875, Screen.height / 2 - 120, 150, 25), "New Game"))
            {
                SceneManager.LoadScene("intro scene");

            }

            if (GUI.Button(new Rect(875, Screen.height / 2 - 75, 150, 25), "Load Game"))
            {

                SceneManager.LoadScene("block scenes");
                loadedGame.Load();

            }

            if (GUI.Button(new Rect(875, Screen.height / 2 - 50, 150, 25), "Settings"))
            {

            }

            if (GUI.Button(new Rect(875, Screen.height / 2 - 25, 150, 25), "Quit Game"))
            {
                Application.Quit();
            }


        }
    }


    void Options()
    {

    }

}
