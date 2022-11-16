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
        Kettle,//TO DO: Change into "Watering Can"
        Camera //Do we need camera?
    }

    public Holdable hold;

    //Sword
    public GameObject sword;
    public GameObject holdSword;
    Animator sword_anim;
    public float swordCDTime;
    float stab_range;
    float sp_counter;
    float swordCD;

    //Watering Can
    public GameObject kettle;//TO DO: Change into "Watering Can"
    public GameObject waterParticle;
    public GameObject specialParticle;
    public float waterInterval = 1;
    Animator kettle_anim;

    void Start()
    {
        swordCD = 0;
        sp_counter = 0;
        stab_range = 1.2f;
        player = GameObject.Find("Player");
        sword_anim = sword.GetComponent<Animator>();
        kettle_anim=kettle.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = player.GetComponent<Player>().dir;
        face = player.GetComponent<Player>().face;
        switch (hold){
            case Holdable.Sword:
                kettle.GetComponent<SpriteRenderer>().enabled = false;
                holdSword.GetComponent<SpriteRenderer>().enabled = true;
                swordAttack();
                break;

            case Holdable.Kettle:
                kettle.GetComponent<SpriteRenderer>().enabled = true;
                holdSword.GetComponent<SpriteRenderer>().enabled = false;
                watering();
                break;
            default:
                kettle.GetComponent<SpriteRenderer>().enabled = false;
                holdSword.GetComponent<SpriteRenderer>().enabled = false;
                break;
        }
    }
    void watering()
    {
        switch (face)
        {
            case 1:
                kettle.transform.position = new Vector3(player.transform.position.x - 0.38f, player.transform.position.y + 0.007f, 0);
                kettle.transform.localScale = new Vector3(1f, 1f, 1f);
                break;

            case 2:
                kettle.transform.position = new Vector3(player.transform.position.x+0.38f, player.transform.position.y +0.007f, 0);
                kettle.transform.localScale = new Vector3(-1f,1f,1f);
                break;
        }
        if (Input.GetKey(KeyCode.X) )
        {
            player.GetComponent<Player>().canMove = false;
            kettle_anim.SetBool("IsWatering",true);

            //Generate Water Particle
            float particleSpeedUp = 50f;
            float particleSpeed = 100f;
            GameObject particle;
            sp_counter+=Time.deltaTime*1;
            if (sp_counter> waterInterval)
            {
                sp_counter = 0;
                //Modifu "WaterParticle_SP" to make watering effect
                particle = Instantiate(specialParticle, new Vector3(kettle.transform.position.x, kettle.transform.position.y - 0.01f, transform.position.z), transform.rotation);
            }
            else
            {
                particle = Instantiate(waterParticle, new Vector3(kettle.transform.position.x, kettle.transform.position.y - 0.01f, transform.position.z), transform.rotation);
            }
            if (face==1)
            {
                particleSpeed = -particleSpeed;
            }

            particle.GetComponent<Rigidbody2D>().AddForce(transform.right * particleSpeed*Random.Range(0.8f,1.2f));
            particle.GetComponent<Rigidbody2D>().AddForce(transform.up * particleSpeedUp * Random.Range(0.8f, 1.2f));

        }
        else
        {
            player.GetComponent<Player>().canMove = true;
            kettle.GetComponent<TriggerCheck>().tar_1 = kettle.GetComponent<TriggerCheck>().tar;
            kettle_anim.SetBool("IsWatering", false);
            sp_counter = 0;
        }
    }

    void swordAttack()
    {
        if (swordCD > 0)
        {
            swordCD -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.X) && swordCD <= 0)
        {
            swordCD = swordCDTime;
            stab_range = 1.2f;
            sword_anim.SetTrigger("Stab");
            player.GetComponent<Player>().canMove = false;
            GameObject tar = sword.GetComponent<TriggerCheck>().tar_1;
            if (tar != null)
            {
                Debug.Log(tar.name);
                if (tar.CompareTag("Wall"))
                {
                    stab_range = 1.035f;
                }
                if (tar.GetComponent<Breakable>())
                {
                    tar.GetComponent<Breakable>().health--;

                }
                //Do something with tar
                sword.GetComponent<TriggerCheck>().tar_1 = null;
            }
        }
        else
        {

            sword.GetComponent<TriggerCheck>().tar_1 = sword.GetComponent<TriggerCheck>().tar;

        }

        if (sword_anim.GetCurrentAnimatorStateInfo(0).IsName("Sword_Attack"))
        {
            holdSword.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<Player>().canMove = false;
        }
        else
        {
            holdSword.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<Player>().canMove = true;
        }

        switch (face)
        {
            case 1:
                holdSword.transform.position = new Vector3(player.transform.position.x + 0.312f, player.transform.position.y + 0.262f, 0);
                holdSword.transform.localScale = new Vector3(-1f, 1f, 1f);
                break;

            case 2:
                holdSword.transform.position = new Vector3(player.transform.position.x -0.312f, player.transform.position.y + 0.263f, 0);
                holdSword.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
        }
        switch (dir)
        {
            case 2:
                sword.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - stab_range, 0);
                sword.transform.eulerAngles = new Vector3(0, 0, 180f);
                //castDir = Vector2.down;
                break;
            case 4:
                sword.transform.position = new Vector3(player.transform.position.x - stab_range, player.transform.position.y, 0);
                sword.transform.eulerAngles = new Vector3(0, 0, 90f);
                //castDir = Vector2.left;
                break;
            case 6:
                sword.transform.position = new Vector3(player.transform.position.x + stab_range, player.transform.position.y, 0);
                sword.transform.eulerAngles = new Vector3(0, 0, -90f);
                //castDir = Vector2.right;
                break;
            case 8:
                sword.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + stab_range, 0);
                sword.transform.eulerAngles = new Vector3(0, 0, 0f);
                //castDir = Vector2.up;
                break;
        }
       
    }
}

   