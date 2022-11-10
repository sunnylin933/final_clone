using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Player Stats
    public int health = 2;
    public int maxHealth=2;//I think we need max health

    //Player Animation
    public Animator animator;

    //Player movement

    public float moveSpeed;

    //Player Ability
    public bool canPush;
    public bool canAttack;
    public bool canWater;
    public List<ItemInfo> inventory = new List<ItemInfo>();

    //Transform or etc related to player
    public GameObject wateringLocation;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        

        if(canWater == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                StartCoroutine("Watering");
                canWater = false;
            }
        }
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
            if(inventory[i].unlockAbility == "canWater")
            {
                this.canWater = true;
            }
        }

    }

    IEnumerator Watering()
    {
        float timeLeft = 3f;

        while(timeLeft >= 0)
        {
            timeLeft -= Time.deltaTime;
            wateringLocation.SetActive(true);
        }
        wateringLocation.SetActive(false);
        yield return null;
    }
}
