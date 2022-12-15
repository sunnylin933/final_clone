using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    //Player Stats
    [Header("Player Stats")]
    public int health = 2;
    public int maxHealth=2;//I think we need max health
    public int dir=6;
    public int face = 2;//1L 2R


    //Player Animation
    public Animator animator;

    //Player Movement
    private RaycastHit2D hit;
    private string[] raycastLayers;
    private LayerMask raycastMask;
    public bool canMove = true;
    public float moveSpeed;

    //Player Ability
    [Header("Player Abilities")]
    public bool isDead;
    public bool canPush;
    public bool canAttack;
    public bool canWater;
    public bool canOpen;
    public bool canLight;
    public GameObject[] flashlight;
    public List<ItemInfo> inventory = new List<ItemInfo>();

    //Transform or etc related to player
    [Header("Miscellaneous")]
    public GameObject cam;
    public GameObject[] roomsActive;
    public GameObject[] roomsInactive;
    public GameObject timer;
    public GameObject wateringLocation;

    //Raycast 
    public RaycastHit2D hit_x;
    public RaycastHit2D hit_y;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        raycastLayers = new string[] { "Blocking", "Actor", "Water" };
        raycastMask = LayerMask.GetMask(raycastLayers);
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0)
        {
            isDead = true;
        }

        if(isDead)
        {
            canMove = false;
            GetComponent<BoxCollider2D>().enabled = false;
            animator.SetBool("isDead", true);
            if (Input.GetKeyDown(KeyCode.X))
            {
                //Reset Rooms
                for(int i = 0; i < roomsActive.Length; i++)
                {
                    roomsActive[i].gameObject.SetActive(true);
                }
                for (int i = 0; i < roomsInactive.Length; i++)
                {
                    roomsInactive[i].gameObject.SetActive(false);
                }
                //Reset Objects
                GameObject[] respawnables = GameObject.FindGameObjectsWithTag("Respawnable");
                for (int i = 0; i <respawnables.Length; i++)
                {
                    respawnables[i].GetComponent<Breakable>().health = 1;
                    respawnables[i].GetComponent<SpriteRenderer>().sprite = respawnables[i].GetComponent<Breakable>().baseSprite;
                    respawnables[i].GetComponent<BoxCollider2D>().enabled = true;
                }
                //Reset Player
                health = maxHealth;
                transform.position = new Vector3(3, -1.35f, 0);
                cam.transform.position = new Vector3(0, -0.5f, -10);
                canMove = true;
                animator.SetBool("isDead", false);
                GetComponent<BoxCollider2D>().enabled = true;
                for(int i =0; i < flashlight.Length; i++)
                {
                    flashlight[i].SetActive(false);
                }

                //Reset Timer
                timer.GetComponent<Timer>().timerStarted = true;
                timer.GetComponent<Timer>().currentTime = timer.GetComponent<Timer>().startTime;


                isDead = false;
            }
        }

        if(Input.GetKeyDown(KeyCode.C) && !isDead)
        {
            timer.GetComponent<AudioSource>().Play();
            timer.GetComponent<Timer>().timerStarted = false;
            animator.SetBool("isDead", true);
            isDead = true;
        }

        if (canWater == true)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("asdf");
                canWater = false;
            }
        }
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if (canMove)
        {
            if (h < 0) { dir = 4; face = 1; }
            if (h > 0) { dir = 6; face = 2; }
            if (v < 0) { dir = 2; }
            if (v > 0) { dir = 8; }
        }

        Vector3 moveDelta = new Vector3(h, v, 0);
        if(canMove && moveDelta != Vector3.zero)
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

        if(canMove)
        {
            hit_x = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.right * h, 0.15f, raycastMask);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.25f), new Vector2(moveDelta.x, 0) * 2, Color.green);
            if (hit_x.transform == null)
            {
                transform.Translate(moveSpeed * moveDelta.x * Time.deltaTime, 0, 0);
            }

            hit_y = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y - 0.25f), Vector2.up * v, 0.15f, raycastMask);
            Debug.DrawRay(new Vector2(transform.position.x, transform.position.y - 0.25f), new Vector2(0, moveDelta.y) * 2, Color.green);
            if (hit_y.transform == null)
            {
                transform.Translate(0, moveSpeed * moveDelta.y * Time.deltaTime, moveSpeed * moveDelta.y * Time.deltaTime);
            }

        }
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
            if(inventory[i].unlockAbility == "canOpen")
            {
                this.canOpen = true;
            }
            if(inventory[i].unlockAbility == "canLight")
            {
                this.canLight = true;
            }
            
        }

    }

}
