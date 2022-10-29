using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 moveDelta = new Vector3(h, v, 0);
        if(moveDelta != Vector3.zero)
        {
            if(moveDelta.x < 0)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if(moveDelta.x > 0)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            animator.SetBool("IsMoving", true);
        }
        else
        {
            animator.SetBool("IsMoving", false);
        }

        transform.Translate(moveSpeed * moveDelta.x * Time.deltaTime, moveSpeed * moveDelta.y * Time.deltaTime, 0);
    }
}
