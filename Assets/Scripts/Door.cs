using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject tilemap;
    public int state = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if( state == 1)
        {
            tilemap.SetActive(true);
        }
        else
        {
            tilemap.SetActive(false);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (state == 1)
            {
                state = 0;
                return;
            }
            if (state == 0)
            {
                state = 1;
                return;
            }
           
        }
    }
}
