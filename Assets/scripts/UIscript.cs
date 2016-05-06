using UnityEngine;
using System.Collections;

public class UIscript : MonoBehaviour
{
    UIinfo canvas;
    bool open;

    void Start()
    {
        canvas = GameObject.Find("Canvas").GetComponent<UIinfo>();
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

        if (open)
        {
            canvas.gameObject.SetActive(true);
        }
        else
        {
            canvas.gameObject.SetActive(false);
        }
    }
}
