using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapChange : MonoBehaviour
{
    public Camera main;
    public Vector3 offset;





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {


            
         

            if (Input.GetKey(KeyCode.S))
            {
                main.transform.position += new Vector3(0, -15f, 0);
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x , collision.gameObject.transform.position.y, 7f);
            }

            if (Input.GetKey(KeyCode.W))
            {
                main.transform.position += new Vector3(0, 15f, 0);
                collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, -7f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                main.transform.position += offset;
                //collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, -7f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                main.transform.position += offset;
                //collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, -7f);
            }


        }
    }
}