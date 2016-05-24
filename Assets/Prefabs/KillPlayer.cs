using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{

    private float nextHit;
    public float Hitrate;
    GUIContent content;
    public Texture text;
    public bool dead = false;
    

    void Start()
    {
        
        content = new GUIContent("", text, "");

    }

    void OnGUI()
    {
        if (dead)
        {
            GUI.Box(new Rect(Screen.width/2 -100, Screen.height/2 - 125, 400, 200), content);
            

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 75, 250, 50), "Exit Game To Desktop"))
            {
                Application.Quit();
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 125, 250, 50), "Exit Game To Main Menu"))
            {
                SceneManager.LoadScene("Main Menu");
                
            }
        }


    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player" && Time.time > nextHit)
        {


            nextHit = Time.time + Hitrate;


            other.gameObject.GetComponent<PlayerStats>().AdjustHP(-10);

            if (other.gameObject.GetComponent<PlayerStats>().currentHP <= 0)
            {

                DestroyObject(other.gameObject);
                dead = true;

            }

        }
    }
}
