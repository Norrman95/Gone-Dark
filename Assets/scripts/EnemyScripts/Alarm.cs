using System.Collections;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Alarm : MonoBehaviour
{
    public AICharacterControl[] Enemy = new AICharacterControl[7];

    void Start()
    {
        for (int i = 0; i < Enemy.Length; i++)
        {
            string ConvertedString = i.ToString();
            Enemy[i] = GameObject.Find("Enemy (" + ConvertedString + ")").GetComponent<AICharacterControl>();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < Enemy.Length; i++)
            {
                if (Vector3.Distance(transform.position, Enemy[i].transform.position) < 50)
                {
                    Enemy[i].Alarm = true;
                }
            }
        }
    }
}

