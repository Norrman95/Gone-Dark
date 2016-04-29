using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{

    private bool firstMenu = true;
    private bool levelSelectMenu = false;
    private bool optionsMenu = false;
    Vector3 StartPos;


    void Start()
    {


    }


    void Update()
    {
        GameObject.Find("Player").transform.position = StartPos;
    }




    void OnGUI()
    {
        FirstMenu();
        Options();
        /// loadedGame = gameObject.GetComponent<SaveLoadGame>();
    }


    void FirstMenu()
    {
        if (firstMenu)
        {
            if (GUI.Button(new Rect(875, Screen.height / 2 - 120, 150, 25), "New Game"))
            {
                SceneManager.LoadScene("intro scene");
                
                
                StartPos = new Vector3(1000000, 100, 100);

            }

            if (GUI.Button(new Rect(875, Screen.height / 2 - 75, 150, 25), "Load Game"))
            {

                SceneManager.LoadScene("block scenes");
                //loadedGame.Load();

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
