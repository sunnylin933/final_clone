using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDown : MonoBehaviour
{
    // A Demo Countdown Mechanic.Unfinished.
    public bool isCounting = false;//Using another script to activate this.
    public float counter;//Assessable for debug use. A timer from 0 to 60
    //public TextMeshPro timerUI; TMPro not working for unknown reason
    public Text timerUI;
    public GameObject player;


    
    void Start()
    {
        isCounting = false;
        counter = 0;

    }

    void Update()
    {
        if (isCounting)
        {

            int time = (int)(60-counter % 60);//Actural timer from 60 to 0

            if (time>0)
            {
                counter += Time.deltaTime;
            }
            else
            {
                //TO DO: Add what happening when count down end
                Debug.Log("Times Up!");
                counter = 0;
                player.transform.position = new Vector3(0,0,0);
            }
            timerUI.text = time.ToString();
        }
    }


}
