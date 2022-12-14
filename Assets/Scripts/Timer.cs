using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
//using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Timer : MonoBehaviour
{
    public Camera main;
    public static bool isViewable = false;
    public float currentTime;
    public float startTime;
    public bool timerStarted;

    public GameObject timer;
    public TMP_Text timerText;
    public GameObject player;

    public int date;

    public GameObject[] everydayGrowable;

    // Start is called before the first frame update
    void Start()
    {
        date = 0;
        currentTime = startTime;
        timerText.text = currentTime.ToString();
        makeGrowableAgain();
    }

    // Update is called once per frame
    void Update()
    {

       

        if (isViewable)
        {
            timer.SetActive(true);

            if (timerStarted)
            {
                currentTime += Time.deltaTime;
            }
            else
                int time = (int)(60 - currentTime % 60);

                if (time <=0 || Input.GetKeyUp(KeyCode.C))
                {
                    //Time end/day end event
                    TimeUpEvents();
                }
                else
                {
                    currentTime += Time.deltaTime;
                }


                timerText.text = time.ToString();
            }
        }
       else
        {
            timer.SetActive(false);
        }
    }

    void TimeUpEvents()
    {
        Debug.Log("Times Up!");
        timerStarted = false;
        currentTime = 0;
        player.transform.position = new Vector3(0, 0, 0);
        date++;
        makeGrowableAgain();
        main.transform.position = new Vector3(0,0,0);
    }

            {
                obj.GetComponent<Growable>().waterable = true;
            }
        }
    }
}
