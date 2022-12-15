using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LighthouseDoor : MonoBehaviour
{
    public GameObject blinker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && Player.instance.canOpen)
        {
            blinker.SetActive(true);
            Destroy(gameObject);
        }
    }
}
