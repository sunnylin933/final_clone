using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Dog : MonoBehaviour
{
    private RaycastHit2D hit;
    private string[] raycastLayers;
    private LayerMask raycastMask;


    public float moveSpeed = 1.25f;
    int xDirection = 1;
    int yDirection = -1;
    // Start is called before the first frame update
    void Start()
    {
        raycastLayers = new string[] { "Blocking", "Player" };
        raycastMask = LayerMask.GetMask(raycastLayers);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit_x;
        RaycastHit2D hit_y;

        hit_x = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.right * xDirection, 0.15f, raycastMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.right * xDirection, Color.green);
        hit_y = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.up * yDirection, 0.15f, raycastMask);
        Debug.DrawRay(new Vector2(transform.position.x, transform.position.y), Vector2.up * yDirection, Color.green);

        if(hit_x.transform != null)
        {
            GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
            xDirection *= -1;
        }

        if (hit_y.transform != null)
        {
            yDirection *= -1;
        }

        transform.Translate(moveSpeed * xDirection * Time.deltaTime, moveSpeed * yDirection * Time.deltaTime, 0);
    }
}
