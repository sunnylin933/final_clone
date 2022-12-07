using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Timer : MonoBehaviour
{
    public static bool isViewable = false;
    public float currentTime;
    public float startTime;
    public bool timerStarted;

    public GameObject timer;
    public TMP_Text timerText;
    public GameObject player;

    public int date;

    // Start is called before the first frame update
    void Start()
    {
        date = 0;
        currentTime = startTime;
        timerText.text = currentTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(isViewable)
        {

            if (Input.GetKeyDown(KeyCode.Slash)) timerStarted = true;

            if (timerStarted)
            {
                int time = (int)(60 - currentTime % 60);

                if (time > 0)
                {
                    currentTime += Time.deltaTime;
                }
                else
                {
                    //Time end/day end event
                    Debug.Log("Times Up!");
                    timerStarted = false;
                    currentTime = 0;
                    player.transform.position = new Vector3(0, 0, 0);
                    date++;
                }

                timerText.text = time.ToString();
            }
        }
       else
        {
            timer.SetActive(false);
        }
    }
}
