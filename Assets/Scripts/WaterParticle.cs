using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticle : MonoBehaviour
{
    GameObject player;
    float playerY;
    float thisY;
    // Start is called before the first frame update
    void Start()
    {
        player= GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerY = player.transform.position.y;
        thisY = this.transform.position.y;
        if (thisY < playerY - 0.5f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision && !collision.CompareTag("Holding") && !collision.CompareTag("WaterParticle"))
        {
            Destroy(this.gameObject);
        }
    }
}
