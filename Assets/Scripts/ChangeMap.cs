using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap : MonoBehaviour
{
    public Camera targetCamera;
    public Camera currentCamera;
    public GameObject targetMap;
    public GameObject currentMap;
    public bool goingDown;
    public bool goingUp;
    public bool goingLeft;
    public bool goingRight;




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            targetMap.SetActive(true);
            currentMap.SetActive(false);
            if(targetCamera != null)
            {
                targetCamera.gameObject.SetActive(true);
                targetCamera.gameObject.SetActive(false);
            }

            if (goingDown == true)
            {
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.transform.position.y, 7.6f);
            }

            if (goingUp == true)
            {
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.transform.position.y, -6f);
            }


        }
    }
}
