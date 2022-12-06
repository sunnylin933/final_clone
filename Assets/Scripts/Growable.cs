using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growable : MonoBehaviour
{
    public int toGrow;
    public int counter = 0;
    public GameObject reward;
    public bool waterable;
    public Sprite[] growStateSprite;

    private void Start()
    {
        
    }

    private void Update()
    {

        if (counter == toGrow)
        {
            this.GetComponent<SpriteRenderer>().sprite = growStateSprite[toGrow];
            var tagName = this.gameObject.tag;
            switch (tagName)
            {
                case "Sprout":
                    Instantiate(reward, this.transform.position, reward.transform.rotation);
                    Destroy(this.gameObject);
                    break;
            }
        }
        else
        {
            this.GetComponent<SpriteRenderer>().sprite = growStateSprite[counter];
        }
    }

}
