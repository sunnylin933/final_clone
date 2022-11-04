using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public string name;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            transform.position += transform.right * -speed * Time.deltaTime;
            if(timer <= -3)
            {
                timer = 3;

            }
        }
        else
        {
            transform.position += transform.right * speed * Time.deltaTime;
        }
    }
}
