using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap : MonoBehaviour
{
    public Camera targetCamera;
    public Camera currentCamera;
    public GameObject targetMap;
    public GameObject currentMap;
    public bool outside;
 




    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.tag == "Player" && outside == false)
        {
            Debug.Log("Asdf");
            outside = true;
            targetMap.SetActive(true);
            currentMap.SetActive(false);
           

         


        }
        else if (collision.gameObject.tag == "Player" && outside == true)
        {
            outside = false;
            targetMap.SetActive(false);
            currentMap.SetActive(true);





        }





    }
}
