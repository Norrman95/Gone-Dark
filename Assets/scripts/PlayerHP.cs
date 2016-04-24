using UnityEngine;
using System.Collections;

public class PlayerHP : MonoBehaviour
{

    public int currentHP;
    private int maxHP;

    public int medkitAmount;

    public void Start()
    {
        maxHP = 30;
    }

    private void useMedkit()
    {
        if (Input.GetButtonDown("Medkit") && medkitAmount >= 1)
        {
            StartCoroutine(Wait(5));
        }
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Medkit();
    }

    public void AdjustHP(int newHP)
    {
        currentHP += newHP;
        print(currentHP);
    }

    void Medkit()
    {
        AdjustHP(20);
        medkitAmount -= 1;
    }

    void Update()
    {
        useMedkit();

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
    }
}
