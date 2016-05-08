using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartPosIntroLevel : MonoBehaviour
{
    Image image;
    private Vector3 startPos;
    UIscript start;

    void Start()
    {
        startPos = new Vector3(0.5f, 16, -50);
        GameObject.Find("Player").transform.position = startPos;
        start = GameObject.Find("Player").GetComponent<UIscript>();


        image = GameObject.Find("BackpackIcon").GetComponent<Image>();
        Color c = image.color;
        c.a = 255;
        image.color = c;
    }




    void Update()
    {
        start.GetComponent<UIscript>().started = true;

    }
}
