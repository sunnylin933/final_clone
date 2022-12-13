using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public string name;
    public float timer;
    public float health;
    public float moveTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(health <= 0)
        {
            if(gameObject.tag == "Crab")
            {
                Debug.Log("df");
                GameManager.crab++;
            }
            Destroy(gameObject);
        }
        if(timer <= 0)
        {
            transform.position += transform.right * -speed * Time.deltaTime;
            if(timer <= -3)
            {
                timer = moveTime;

            }
        }
        else
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }

    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Sword")
        {
            health--;
           
        }
    }
    */
}
