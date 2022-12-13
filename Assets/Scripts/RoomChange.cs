using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    public Camera targetCamera;
    public Camera currentCamera;
    public GameObject targetMap;
    public GameObject currentMap;
    public bool needskey = false;
    public bool outside;
 




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (needskey == false)
            {
                Debug.Log("Asdf");
                outside = true;
                targetMap.SetActive(true);
                currentMap.SetActive(false);
            }
            else
            {
                if(collision.gameObject.GetComponent<Player>().canOpen == true)
                {
                    outside = true;
                    targetMap.SetActive(true);
                    currentMap.SetActive(false);
                }
            }
           
        }
        /*
        else if (collision.gameObject.CompareTag("Player"))
        {
            outside = false;
            targetMap.SetActive(false);
            currentMap.SetActive(true);





        }


        */


    }
}
