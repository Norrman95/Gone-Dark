using UnityEngine;
using System.Collections;

public class TheEnd : MonoBehaviour
{
    bool showGUI = false;
    bool end = false;
    GUIContent content;
    public Texture texture;
    GameObject player;


    void Start()
    {
        player = GameObject.Find("Player");
        content = new GUIContent("", texture, "");
    }




    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            showGUI = true;

        }
    }

    void OnGUI()
    {
        if (showGUI)
        {
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), content);
            Time.timeScale = 0;

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 125, 250, 50), "Exit Game To Desktop"))
            {
                Application.Quit();
            }
        }


    }






    void Update()
    {

    }



}
