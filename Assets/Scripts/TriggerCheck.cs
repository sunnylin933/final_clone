using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    public List<GameObject> targets;
    public GameObject tar;
    // Start is called before the first frame update
    void Start()
    {
        // List<GameObject> targets = new List<GameObject>();
        tar = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // targets.Add(collision.gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        tar = collision.gameObject;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tar = null;
        //List<GameObject> targets = new List<GameObject>();
    }
}
