using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIinfo : MonoBehaviour
{
    Text[] text = new Text[5];
    Image[] image = new Image[6];
    PlayerInventory inv;
    UIscript ui;

    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 6)
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
       

        ui = GameObject.Find("Player").GetComponent<UIscript>();
        inv = GameObject.Find("Player").GetComponent<PlayerInventory>();
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
        image[5] = GameObject.Find("MedkitPic").gameObject.GetComponent<Image>();
    }

    void Update()
    {
        if (ui.GetComponent<UIscript>().open)
        {
            if (inv.GetComponent<PlayerInventory>().redKeycard)
            {
                image[0].gameObject.SetActive(true);
            }
            else
            {
                image[0].gameObject.SetActive(false);
            }

            if (inv.GetComponent<PlayerInventory>().blueKeycard)
            {
                image[1].gameObject.SetActive(true);
            }
            else
            {
                image[1].gameObject.SetActive(false);
            }

            if (inv.GetComponent<PlayerInventory>().yellowKeycard)
            {
                image[2].gameObject.SetActive(true);
            }
            else
            {
                image[2].gameObject.SetActive(false);
            }

            if (inv.GetComponent<PlayerInventory>().pistol)
            {
                Color c = image[3].color;
                c.a = 0;
                image[3].color = c;
            }
            else
            {
                Color c = image[3].color;
                c.a = 255;
                image[3].color = c;
            }

            if (inv.GetComponent<PlayerInventory>().shotgun)
            {
                Color c = image[4].color;
                c.a = 0;
                image[4].color = c;
            }
            else
            {
                Color c = image[4].color;
                c.a = 255;
                image[4].color = c;
            }

            
            text[0].text = "Pistol Magazines : " + inv.GetComponent<PlayerInventory>().pistolMag;
            text[1].text = "Shotgun Shells : " + inv.GetComponent<PlayerInventory>().totalShells;
            text[2].text = "Medkits : " + inv.GetComponent<PlayerInventory>().medkitAmount;
            text[3].text = inv.GetComponent<PlayerInventory>().currentpistolAmmo + "/8";
            text[4].text = inv.GetComponent<PlayerInventory>().currentShells + "/2";
        }

 
    }
}
