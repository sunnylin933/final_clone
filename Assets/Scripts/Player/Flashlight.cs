using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public GameObject flashLightLight;
    public GameObject flashLightDark;
    public bool haveFlashlight;
    public bool isDark;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(haveFlashlight && isDark)
        {
            flashLightLight.SetActive(true);
            flashLightDark.SetActive(false);
        }
        else if (isDark)
        {
            flashLightLight.SetActive(false);
            flashLightDark.SetActive(true);
        }
        else{
            flashLightLight.SetActive(false);
            flashLightDark.SetActive(false);
        }
    }
}
