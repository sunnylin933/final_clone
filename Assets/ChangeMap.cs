using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMap : MonoBehaviour
{
    public Camera main;
    




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
<<<<<<< Updated upstream:Assets/ChangeMap.cs
            targetMap.SetActive(true);
            currentMap.SetActive(false);
            targetCamera.gameObject.SetActive(true);
            targetCamera.gameObject.SetActive(false);

            if(goingDown == true)
=======
            
         

            if (Input.GetKey(KeyCode.S))
            {
                main.transform.position += new Vector3(0, -15f, 0);
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x , collision.gameObject.transform.position.y, 7f);
            }

            if (Input.GetKey(KeyCode.W))
>>>>>>> Stashed changes:Assets/Scripts/ChangeMap.cs
            {
                main.transform.position += new Vector3(0, 15f, 0);
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, -7f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                main.transform.position += new Vector3(-20f, 0, 0);
                //collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, -7f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                main.transform.position += new Vector3(20f, 0, 0);
                //collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, -7f);
            }


        }
    }
}
