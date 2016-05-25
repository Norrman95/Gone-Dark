using System.Collections;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    public EnemyAi[] Enemy = new EnemyAi[7];

    void Start()
    {
        for (int i = 0; i < Enemy.Length; i++)
        {
            string ConvertedString = i.ToString();
            Enemy[i] = GameObject.Find("Enemy (" + ConvertedString + ")").GetComponent<EnemyAi>();
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

