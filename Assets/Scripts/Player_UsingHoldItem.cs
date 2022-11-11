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
        Kettle,
        Camera //Do we need camera?
    }

    public Holdable hold;

    //Sword
    public GameObject sword;
    public GameObject holdSword;
    Animator sword_anim;

    //Kettle
    public GameObject kettle;
    public GameObject waterParticle;
    Animator kettle_anim;
    void Start()
    {
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
                kettle.transform.position = new Vector3(player.transform.position.x - 0.08f, player.transform.position.y + 0.02f, 0);
                kettle.transform.localScale = new Vector3(1f, 1f, 1f);
                break;

            case 2:
                kettle.transform.position = new Vector3(player.transform.position.x+0.08f, player.transform.position.y +0.02f, 0);
                kettle.transform.localScale = new Vector3(-1f,1f,1f);
                break;
        }
        if (Input.GetKey(KeyCode.X))
        {
            player.GetComponent<Player>().canMove = false;
            kettle_anim.SetBool("IsWatering",true);
            GameObject tar = kettle.GetComponent<TriggerCheck>().tar_1;
            //Generate Water Particle
            float particleSpeedUp = 20f;
            float particleSpeed = 30f;
            GameObject particle = Instantiate(waterParticle, new Vector3(kettle.transform.position.x, kettle.transform.position.y-0.01f, transform.position.z), transform.rotation);
            if (face==1)
            {
                particleSpeed = -particleSpeed;
            }

            particle.GetComponent<Rigidbody2D>().AddForce(transform.right * particleSpeed*Random.Range(0.8f,1.2f));
            particle.GetComponent<Rigidbody2D>().AddForce(transform.up * particleSpeedUp * Random.Range(0.8f, 1.2f));
            if (tar != null)
            {
                Debug.Log(tar.name);
                kettle.GetComponent<TriggerCheck>().tar_1 = null;
            }
        }
        else
        {
            player.GetComponent<Player>().canMove = true;
            kettle.GetComponent<TriggerCheck>().tar_1 = kettle.GetComponent<TriggerCheck>().tar;
            kettle_anim.SetBool("IsWatering", false);
        }
    }

    void swordAttack()
    {
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
                holdSword.transform.position = new Vector3(player.transform.position.x + 0.056f, player.transform.position.y + 0.0688f, 0);
                holdSword.transform.localScale = new Vector3(-1f, 1f, 1f);
                break;

            case 2:
                holdSword.transform.position = new Vector3(player.transform.position.x -0.056f, player.transform.position.y + 0.0688f, 0);
                holdSword.transform.localScale = new Vector3(1f, 1f, 1f);
                break;
        }
        switch (dir)
        {
            case 2:
                sword.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - 0.2f, 0);
                sword.transform.eulerAngles = new Vector3(0, 0, 180f);
                //castDir = Vector2.down;
                break;
            case 4:
                sword.transform.position = new Vector3(player.transform.position.x - 0.2f, player.transform.position.y, 0);
                sword.transform.eulerAngles = new Vector3(0, 0, 90f);
                //castDir = Vector2.left;
                break;
            case 6:
                sword.transform.position = new Vector3(player.transform.position.x + 0.2f, player.transform.position.y, 0);
                sword.transform.eulerAngles = new Vector3(0, 0, -90f);
                //castDir = Vector2.right;
                break;
            case 8:
                sword.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + 0.2f, 0);
                sword.transform.eulerAngles = new Vector3(0, 0, 0f);
                //castDir = Vector2.up;
                break;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            sword_anim.SetTrigger("Stab");
            player.GetComponent<Player>().canMove = false;
            GameObject tar = sword.GetComponent<TriggerCheck>().tar_1;
            if (tar != null)
            {
                Debug.Log(tar.name);
                //Do something with tar
                sword.GetComponent<TriggerCheck>().tar_1 = null;
            }
        }
        else
        {
            sword.GetComponent<TriggerCheck>().tar_1 = sword.GetComponent<TriggerCheck>().tar;
        }
    }
}

   