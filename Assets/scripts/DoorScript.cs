using UnityEngine;
using System.Collections;

public class DoorScript : MonoBehaviour
{
    public bool redDoor, blueDoor, yellowDoor, Open;
    private bool canOpen, inRange;

    private PlayerInventory playerInv;
    private int count;

    void Start()
    {
        playerInv = GameObject.Find("Player").GetComponent<PlayerInventory>();
    }

    void Update()
    {
        if (count > 0)
        {
            Open = true;
        }
        else
        {
            Open = false;
        }
    }

    public void saveDoorstatus()
    {
        PlayerPrefs.SetInt("Open", (Open ? 1 : 0));
    }
    public void loadDoorstatus()
    {
        Open = (PlayerPrefs.GetInt("Open") != 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (redDoor)
            {
                if (playerInv.GetComponent<PlayerInventory>().redKeycard)
                {
                    count++;
                }

                else
                {

                }
            }
            else if (blueDoor)
            {
                if (playerInv.GetComponent<PlayerInventory>().blueKeycard)
                {
                    count++;
                }
                else
                {

                }
            }
            else if (yellowDoor)
            {
                if (playerInv.GetComponent<PlayerInventory>().yellowKeycard)
                {
                    count++;
                }
                else
                {

                }
            }
            else
            {
                count++;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && other is CapsuleCollider)
        {
            count = Mathf.Max(0, count - 1);
        }
    }
}
