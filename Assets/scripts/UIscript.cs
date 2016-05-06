using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIscript : MonoBehaviour
{
    Text[] text = new Text[5];
    Image[] image = new Image[7];

    MainMenu menu;
    public bool open = false;

    void Start()
    {
        menu = GameObject.Find("Canvas").gameObject.GetComponent<MainMenu>();

        text[0] = GameObject.Find("PistolMag").gameObject.GetComponent<Text>();
        text[1] = GameObject.Find("ShotgunShells").gameObject.GetComponent<Text>();
        text[2] = GameObject.Find("Medkits").gameObject.GetComponent<Text>();
        text[3] = GameObject.Find("CurrentPistol").gameObject.GetComponent<Text>();
        text[4] = GameObject.Find("CurrentShotgun").gameObject.GetComponent<Text>();

        image[0] = GameObject.Find("RedKeycard").gameObject.GetComponent<Image>();
        image[1] = GameObject.Find("BlueKeycard").gameObject.GetComponent<Image>();
        image[2] = GameObject.Find("YellowKeycard").gameObject.GetComponent<Image>();
        image[3] = GameObject.Find("Shotgun").gameObject.GetComponent<Image>();
        image[4] = GameObject.Find("Pistol").gameObject.GetComponent<Image>();
        image[5] = GameObject.Find("Background").GetComponent<Image>();

        image[6] = GameObject.Find("BackpackIcon").GetComponent<Image>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!open)
            {
                open = true;
            }
            else
            {
                open = false;
            }
        }

        OpenInventory();
    }

    void OpenInventory()
    {
        if (open)
        {
            for (int i = 0; i < 6; i++)
            {
                image[i].gameObject.SetActive(true);
            }
            for (int i = 0; i < 5; i++)
            {
                text[i].gameObject.SetActive(true);
            }
            image[6].gameObject.SetActive(false);
        }
        else
        {
            for (int i = 0; i < 6; i++)
            {
                image[i].gameObject.SetActive(false);
            }
            for (int i = 0; i < 5; i++)
            {
                text[i].gameObject.SetActive(false);
            }
            image[6].gameObject.SetActive(true);
        }
    }
}
