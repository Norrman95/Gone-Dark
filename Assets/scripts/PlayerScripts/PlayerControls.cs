using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{
    private float moveSpeed;
    private float maxSpeed;
    private bool usingMedkit = false;
        LightRays Rays;
    void Start()
    {

    Rays = GameObject.Find("LightRays").GetComponent<LightRays>();
    }

    void Update()
    {
        PlayerMovement();
        UsingMedkit();


    }

    public void PlaySound(int number)
    {
        if (number == 1)
        {
            GetComponent<AudioSource>().Play();
        }
    }
    private void UsingMedkit()
    {
        if (Input.GetButtonDown("Medkit"))
        {
            StartCoroutine(Wait(5));
            usingMedkit = true;
        }
    }

    private IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);

        if (usingMedkit)
        {
            UsedMedkit();
            usingMedkit = false;
        }
    }

    void UsedMedkit()
    {
        GetComponent<PlayerStats>().AdjustHP(20);
        GetComponent<PlayerInventory>().medkitAmount -= 1;
    }

    void PlayerMovement()
    {
        if (Input.GetButton("Sprint") && GetComponent<PlayerStats>().currentStamina >= 1)
        {
            GetComponent<PlayerStats>().running = true;
            moveSpeed = 15;
        }
        else
        {
            GetComponent<PlayerStats>().running = false;
            moveSpeed = 30f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= Vector3.forward * Time.deltaTime * moveSpeed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Vector3.right * Time.deltaTime * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * Time.deltaTime * moveSpeed;
        }
    }
}
