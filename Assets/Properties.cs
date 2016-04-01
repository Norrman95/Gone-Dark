using UnityEngine;
using System.Collections;

public class Properties : MonoBehaviour
{

 

    public int HP { get; set; }

    public Properties(int HP)
    {
        this.HP = 100;
    }


}
