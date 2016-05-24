using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StoryManager : MonoBehaviour
{
    private bool showStory = true;
    private bool exited = false;
    private bool showFirst = true;
    private bool showSecond = false;
    private bool showmore = true;
    private MainMenu getmenu;
    private Rect textarea;
    private Rect buttonPos;
    private Rect buttonPos2;
    GUIContent content;
    GUIStyle style;
    



    void Start()
    {

        content = new GUIContent();
        textarea = new Rect(Screen.width / 2 - 850, Screen.height / 2 - 300, 400, 300);
        buttonPos = new Rect(Screen.width / 2 - 850, Screen.height / 3 + 150, 150, 25);
        buttonPos2 = new Rect(Screen.width / 2 - 700, Screen.height / 3 + 150, 150, 25);
        style.fontSize = 1;

    }


    void Update()
    {

    }

    void OnGUI()
    {
        if (SceneManager.GetActiveScene().name != "Main Menu")
        {
            StoryScreen();
        }
    }


    void StoryScreen()
    {
        if (!exited && showStory)
        {
            showStory = true;
            GUI.Box(textarea, content);
            if (showFirst && !showSecond)
            {
                GUI.Label(textarea, "Lucy was tired, she had been working for months now and had only made little progress. All while at the same time trying to balance it with her work and personal life. She was an up and coming journalist. She had already put her name on several stories, but mostly only as a helper or assistant. Now she was looking to make a name for herself with this story. \n She was brought out of her thinking by the sound of her telephone ringing. She got up and answered it. \n “Lucy Born.” She said and in responds a familiar male voice spoke from the other end. \n “Lucy it’s me Marcus.” Marcus Cambear was her info seeker for this story. Lucy knew very little about him, but had already worked with him on some of the other stories. He had certain skills in finding the right people, leads and info and so far it was always top notch. \n “I finally found something about that German guy Hans. After he immigrated to the USA he was hired by the government to continue his experiments here, with a bigger budget of course.” Lucy couldn’t believe it.");

            }
            if (showmore)
            {
                if (GUI.Button(buttonPos2, "More"))
                {
                    showFirst = false;
                    showSecond = true;
                    showmore = false;
                }

            }



            if (showSecond && !showFirst)
            {
                GUI.Label(textarea, "Didn’t they know who they we’re dealing with, what kind of sick stuff he did back in Germany? Marcus continued giving more info. “Get this it seems like he really hit it off with this other scientist named Steven Crom and both of them decided to work together.So with the government backing they left their previous workplaces to start some kind of lab under their control.When Hans died two years back Steven took fully over the lab.Now the location of the lab was kept secret, but I managed to get my hands on some papers that should lead us to the labs location.Don’t ask me how I got these, for now let’s just say it was a nightmare and that the amount of cleaning up my trails that I did was complete insanity. Lucy was taking all of this in. it was a lot, but it made her even more excited to go out and finish her story. And the first step was finding that lab.");

            }


            if (GUI.Button(buttonPos, "Close"))
            {
                showStory = false;
                exited = true;
            }

        }
    }


}
