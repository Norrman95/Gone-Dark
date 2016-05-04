using UnityEngine;
using System.Collections;

public class ItemData : MonoBehaviour
{
    public ItemPickup[] Item = new ItemPickup[2];
    public ItemPickup itemData;

    void Start()
    {
        itemData = GameObject.Find("Item").GetComponent<ItemPickup>();
        Item[0] = GameObject.Find("Item").GetComponent<ItemPickup>();
        Item[1] = GameObject.Find("Item1").GetComponent<ItemPickup>();
    }

    void Update()
    {
        for (int i = 0; i < Item.Length; i++)
        {
            if (Item[i].pickedUp)
            {
                Item[i].gameObject.SetActive(false);
            }
            else
            {
                Item[i].gameObject.SetActive(true);
            }
        }


        if (Input.GetKeyDown(KeyCode.L))
        {
            itemData.loadItemstatus();
        }
    }
}
