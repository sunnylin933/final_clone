using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Timer : MonoBehaviour
{
    public static bool isViewable = false;
    public float currentTime;
    public float startTime;
    public bool timerStarted;

    public TMP_Text timerText;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        timerText.text = currentTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Slash))
        {
            timerStarted = true;
        }

        if(timerStarted)
        {
            int time = (int)(60 - currentTime % 60);

            if (time > 0)
            {
                currentTime += Time.deltaTime;
            }
            else
            {
                Debug.Log("Times Up!");
                timerStarted = false;
                currentTime = 0;
                player.transform.position = new Vector3(0, 0, 0);
            }

            timerText.text = time.ToString();
        }
    }
}
