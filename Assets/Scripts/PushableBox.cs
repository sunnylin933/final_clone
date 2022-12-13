using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushableBox : MonoBehaviour
{
    Rigidbody2D rb;
    Player player;

    public bool canPush;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        canPush = player.canPush;
        if (canPush)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            this.gameObject.layer = LayerMask.NameToLayer("Default");

        }
        else
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
            this.gameObject.layer= LayerMask.NameToLayer("Blocking");
        }


    }

}
