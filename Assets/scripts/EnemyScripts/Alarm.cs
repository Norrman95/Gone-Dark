using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.ThirdPerson;

public class Alarm : MonoBehaviour
{
    public GameObject[] enemy;
    private AICharacterControl aicharactercontrol;


    void Start()
    {
        enemy = GameObject.FindGameObjectsWithTag("Enemy");



    }
    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            for (int i = 0; i < enemy.Length; i++)
            {
                if (Vector3.Distance(transform.position, enemy[i].transform.position) < 10)
                {

                    enemy[i].GetComponent<AICharacterControl>().Alarm=true;
                    //enemy[i].GetComponent<AICharacterControl>().agent.enabled = true;
                    Debug.Log("collide and enemy nearby");

                }

            }
        }
    }
}
