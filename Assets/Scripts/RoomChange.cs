using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomChange : MonoBehaviour
{
    public Camera targetCamera;
    public Camera currentCamera;
    public GameObject[] targetMap;
    public GameObject[] currentMap;
    public bool needskey = false;
    public bool temple = false;
    public bool outside;
    public bool goingOut;
 




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(goingOut == true)
        {
            collision.gameObject.GetComponent<Flashlight>().isDark = false;
            

        }
        if (collision.gameObject.CompareTag("Player"))
        {
            if (needskey == false)
            {
                if(temple == false)
                {
                    
                    outside = true;
                    for (int i = 0; i < targetMap.Length; i++)
                    {
                        targetMap[i].SetActive(true);
                    }
                    for (int i = 0; i < currentMap.Length; i++)
                    {
                        currentMap[i].SetActive(false);
                    }

                }
                if(temple == true)
                {
                    if(collision.gameObject.GetComponent<Player>().canLight == true)
                    {
                        collision.gameObject.GetComponent<Flashlight>().isDark = true;
                        collision.gameObject.GetComponent<Flashlight>().haveFlashlight = true;
                        outside = true;
                        outside = true;
                        for (int i = 0; i < targetMap.Length; i++)
                        {
                            targetMap[i].SetActive(true);
                        }
                        for (int i = 0; i < currentMap.Length; i++)
                        {
                            currentMap[i].SetActive(false);
                        }
                    }
                    else
                    {
                        collision.gameObject.GetComponent<Flashlight>().isDark = true;
                        outside = true;
                        outside = true;
                        for (int i = 0; i < targetMap.Length; i++)
                        {
                            targetMap[i].SetActive(true);
                        }
                        for (int i = 0; i < currentMap.Length; i++)
                        {
                            currentMap[i].SetActive(false);
                        }

                    }
                    
                }
              
            }
           
            else
            {
                if(collision.gameObject.GetComponent<Player>().canOpen == true)
                {
                    outside = true;
                    outside = true;
                    for (int i = 0; i < targetMap.Length; i++)
                    {
                        targetMap[i].SetActive(true);
                    }
                    for (int i = 0; i < currentMap.Length; i++)
                    {
                        currentMap[i].SetActive(false);
                    }
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
