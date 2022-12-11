using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_UsingHoldItem : MonoBehaviour
{
    public GameObject player;
    int dir;
    int face;

    public enum Holdable
    {
        None,
        Sword,
        WateringCan
    }

    public Holdable hold;

    //Sword
    public GameObject sword;
    public GameObject holdSword;
    Animator swordAnim;
    public float swordCDTime;
    float stabRange = 1.2f;
    float spCounter;
    float swordCD = 0;

    //Watering Can
    public GameObject wateringCan;
    public GameObject waterParticle;
    public GameObject specialParticle;
    public float waterInterval = 1;
    Animator wateringCanAnim;

    void Start()
    {
        spCounter = 0;
        player = GameObject.Find("Player");
        swordAnim = sword.GetComponent<Animator>();
        wateringCanAnim=wateringCan.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = player.GetComponent<Player>().dir;
        face = player.GetComponent<Player>().face;
        switch (hold){
            case Holdable.Sword:
                EnableSword();
                CheckSwordDirection();
                CheckSwordInput();
                CheckCanMove();

                if (swordCD > 0)
                {
                    swordCD -= Time.deltaTime;
                }
                break;

            case Holdable.WateringCan:
                wateringCan.GetComponent<SpriteRenderer>().enabled = true;
                holdSword.GetComponent<SpriteRenderer>().enabled = false;
                Watering();
                break;
            default:
                wateringCan.GetComponent<SpriteRenderer>().enabled = false;
                holdSword.GetComponent<SpriteRenderer>().enabled = false;
                break;
        }
    }
    void Watering()
    {
        CheckFacingDirection();

        if (Input.GetKey(KeyCode.X) )
        {
            player.GetComponent<Player>().canMove = false;
            wateringCanAnim.SetBool("IsWatering",true);

            //Generate Water Particle
            float particleSpeedUp = 50f;
            float particleSpeed = 100f;
            GameObject particle;
            spCounter+=Time.deltaTime*1;
            if (spCounter> waterInterval)
            {
                spCounter = 0;
                //Modifu "WaterParticle_SP" to make watering effect
                particle = Instantiate(specialParticle, new Vector3(wateringCan.transform.position.x, wateringCan.transform.position.y - 0.01f, transform.position.z), transform.rotation);
            }
            else
            {
                particle = Instantiate(waterParticle, new Vector3(wateringCan.transform.position.x, wateringCan.transform.position.y - 0.01f, transform.position.z), transform.rotation);
            }
            if (face==1)
            {
                particleSpeed = -100f;
            }

            particle.GetComponent<Rigidbody2D>().AddForce(transform.right * particleSpeed*Random.Range(0.8f,1.2f));
            particle.GetComponent<Rigidbody2D>().AddForce(transform.up * particleSpeedUp * Random.Range(0.8f, 1.2f));

        }
        else
        {
            player.GetComponent<Player>().canMove = true;
            wateringCan.GetComponent<TriggerCheck>().tar_1 = wateringCan.GetComponent<TriggerCheck>().tar;
            wateringCanAnim.SetBool("IsWatering", false);
            spCounter = 0;
        }
    }


    //Sword Methods
    public void EnableSword()
    {
        wateringCan.GetComponent<SpriteRenderer>().enabled = false;
        holdSword.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void CheckSwordInput()
    {
        if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if (swordCD <= 0)
            {
                SwordAttack();
            }
        }
    }

    void SwordAttack()
    {
        player.GetComponent<Player>().canMove = false;
        swordAnim.SetTrigger("Stab");
        CheckTargets();
        swordCD = swordCDTime;
    }

    public void CheckCanMove()
    {
        if (swordAnim.GetCurrentAnimatorStateInfo(0).IsName("Sword_Attack"))
        {
            holdSword.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<Player>().canMove = false;
        }
        else
        {
            holdSword.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<Player>().canMove = true;
        }
    }

    public void CheckSwordDirection()
    {
        switch (face)
        {
            case 1:
                holdSword.transform.position = new Vector3(player.transform.position.x + 0.312f, player.transform.position.y + 0.262f, 0);
                holdSword.transform.localScale = new Vector3(-1f, 1f, 1f);
                break;

            case 2:
                holdSword.transform.position = new Vector3(player.transform.position.x - 0.312f, player.transform.position.y + 0.263f, 0);
                holdSword.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
        }
        switch (dir)
        {
            case 2:
                sword.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - stabRange, 0);
                sword.transform.eulerAngles = new Vector3(0, 0, 180f);
                //castDir = Vector2.down;
                break;
            case 4:
                sword.transform.position = new Vector3(player.transform.position.x - stabRange, player.transform.position.y, 0);
                sword.transform.eulerAngles = new Vector3(0, 0, 90f);
                //castDir = Vector2.left;
                break;
            case 6:
                sword.transform.position = new Vector3(player.transform.position.x + stabRange, player.transform.position.y, 0);
                sword.transform.eulerAngles = new Vector3(0, 0, -90f);
                //castDir = Vector2.right;
                break;
            case 8:
                sword.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + stabRange, 0);
                sword.transform.eulerAngles = new Vector3(0, 0, 0f);
                //castDir = Vector2.up;
                break;
        }
    }
    public void CheckTargets()
    {
        List<GameObject> tar = sword.GetComponent<TriggerCheck>().targets;
        if (tar != null)
        {
            for (int i = 0; i < tar.Count; i++)
            {
                if (tar[i].CompareTag("Wall"))
                {
                    stabRange = 1.035f;
                }
                if (tar[i].GetComponent<Breakable>())
                {
                    tar[i].GetComponent<Breakable>().health--;

                }
            }
            sword.GetComponent<TriggerCheck>().targets.Clear();
        }
    }

    //Watering Can Methods
    public void CheckFacingDirection()
    {
        switch (face)
        {
            case 1:
                wateringCan.transform.position = new Vector3(player.transform.position.x - 0.38f, player.transform.position.y + 0.007f, 0);
                wateringCan.transform.localScale = new Vector3(1f, 1f, 1f);
                break;

            case 2:
                wateringCan.transform.position = new Vector3(player.transform.position.x + 0.38f, player.transform.position.y + 0.007f, 0);
                wateringCan.transform.localScale = new Vector3(-1f, 1f, 1f);
                break;
        }
    }
}

   