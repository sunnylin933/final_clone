using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    //I use Player_UsingHoldItem to detect this
    public int health;
    public Sprite next_sprite;


    private void Update()
    {
        if (health <= 0)
        {
            this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            this.gameObject.GetComponent<SpriteRenderer>().sprite = next_sprite;

        }

    }



}
