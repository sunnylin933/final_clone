using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public GameObject tar;
    public GameObject tar_1;

    void Start()
    {
        tar = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision &&!collision.CompareTag("WaterParticle"))
        {
            tar_1 = collision.gameObject;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision && !collision.CompareTag("WaterParticle"))
        {
            tar = collision.gameObject;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tar = null;
        tar_1 = null;
    }


}
