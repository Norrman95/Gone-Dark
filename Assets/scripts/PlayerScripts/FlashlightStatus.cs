using UnityEngine;
using System.Collections;

public class FlashlightStatus : MonoBehaviour
{
    Ray cameraRay;
    LightRays Rays;
    Light light;
    bool flashlight = true;

    void Start()
    {
        Rays = GameObject.Find("LightRays").GetComponent<LightRays>();
        light = GameObject.Find("Spotlight").GetComponent<Light>();
    }
    void Update()
    {
        if (flashlight)
        {
            light.gameObject.SetActive(true);
            Rays.gameObject.SetActive(true);
        }
        else
        {
            light.gameObject.SetActive(false);
            Rays.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (flashlight)
            {
                flashlight = false;
            }
            else
            {
                flashlight = true;
            }
        }
    }
}
