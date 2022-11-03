using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Player Stats
    public int health = 2;

    //Player Animation
    public Animator animator;

    //Player movement

    public float moveSpeed;

    //Player Ability
    public bool canPush;
    public bool canAttack;
    public List<ItemInfo> inventory = new List<ItemInfo>();
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



   public void UnlockAbility()
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i].unlockAbility == "canAttack")
            {
                this.canAttack = true;
            }
            if(inventory[i].unlockAbility == "canPush")
            {
                this.canPush = true;
            }
        }

    }
}
