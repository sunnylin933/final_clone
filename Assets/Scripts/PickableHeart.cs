using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableHeart : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            collision.GetComponent<Player>().maxHealth++;
            collision.GetComponent<Player>().health++;
            Destroy(this.gameObject);
        }
    }
}
