using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MapChange : MonoBehaviour
{
    public Camera main;
    private GameObject player;
    public Vector3 verticalOffset;
    public Vector3 horizontalOffset;

    [Header("Allowed Movement")]
    public bool horizontal;
    public bool vertical;
    

    private void Awake()
    {
        //this is for player "boosting" to get them into the next map quickly
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            float h = Input.GetAxisRaw("Horizontal");
            if (horizontal)
            {
                if (h<0)
                {
                    //Input.GetKey(KeyCode.A)
                    main.transform.position -= horizontalOffset;
                    //collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, -7f);
                    player.transform.position = new Vector3(player.transform.position.x - 2, player.transform.position.y, player.transform.position.z);
                }
                if (h>0)//Input.GetKey(KeyCode.D)
                {
                    main.transform.position += horizontalOffset;
                    //collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, -7f);
                    player.transform.position = new Vector3(player.transform.position.x + 2, player.transform.position.y, player.transform.position.z);
                }
            }


            if(vertical)
            {

                float v = Input.GetAxisRaw("Vertical");
                if (v<0)//Input.GetKey(KeyCode.S)
                {
                    main.transform.position -= verticalOffset;
                    collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, 7f);
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 2, player.transform.position.z);
                }

                if (v>0)//Input.GetKey(KeyCode.W)

                {
                    main.transform.position += verticalOffset;
                    collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, -7f);
                    player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 2, player.transform.position.z);
                }
            }
        }
    }
}