using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    //I use Player_UsingHoldItem to detect this
    public int health;
    public bool canDelete;
    public bool isDestroyed;
    public Sprite baseSprite;
    public Sprite[] destroyedSprites;


    private void Start()
    {
        baseSprite= GetComponent<SpriteRenderer>().sprite;
    }


    private void Update()
    {
        if(canDelete)
        {
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (health <= 0 && !isDestroyed)
            {
                int randomSprite = Random.Range(0, destroyedSprites.Length);
                GetComponent<SpriteRenderer>().sprite = destroyedSprites[randomSprite];
                GetComponent<BoxCollider2D>().enabled = false;
                isDestroyed = true;
            }
        }
    }



}
