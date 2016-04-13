using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {

    private bool firstMenu = true;
    private bool levelSelectMenu = false;
    private bool optionsMenu = false;

	void Start () {
	
	}
	

	void Update () {
	
	}




    void OnGUI()
    {
        FirstMenu();
        Options();

    }


    void FirstMenu()
    {
        if(firstMenu)
        {
            if(GUI.Button(new Rect(10, Screen.height/ 2 - 100, 150, 25),"New Game"))
            {
                SceneManager.LoadScene("block scenes");  
            
            }

            if (GUI.Button(new Rect(10, Screen.height / 2 - 75, 150, 25), "Load Game"))
            {

            }

            if (GUI.Button(new Rect(10, Screen.height / 2 - 50, 150, 25), "Settings"))
            {

            }

            if (GUI.Button(new Rect(10, Screen.height / 2 - 25, 150, 25), "Quit Game"))
            {
                Application.Quit();
            }
        
        
        }
    }


    void Options()
    {

    }

}
