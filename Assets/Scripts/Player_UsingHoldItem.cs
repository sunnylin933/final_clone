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
        WateringCan,//TO DO: Change into "Watering Can"
        Camera //Do we need camera?
    }

    public Holdable hold;

    //Sword
    //public GameObject sword;
    public GameObject holdSword;
    public GameObject swordAttackObject;

    Animator swordAnim;
    public float swordCDTime;
    float stabRange;
    float spCounter;
    float swordCD;

    //Watering Can
    public GameObject wateringCan;
    public GameObject waterParticle;
    public GameObject specialParticle;
    public float waterInterval = 1;
    Animator wateringCanAnim;

    void Start()
    {
        swordCD = 0;
        spCounter = 0;
        stabRange = 1.2f;
        player = GameObject.Find("Player");
        //swordAnim = sword.GetComponent<Animator>();
        wateringCanAnim=wateringCan.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = player.GetComponent<Player>().dir;
        face = player.GetComponent<Player>().face;
        switch (hold){
            case Holdable.Sword:
                wateringCan.GetComponent<SpriteRenderer>().enabled = false;
                holdSword.GetComponent<SpriteRenderer>().enabled = true;
                swordAttack();
                break;

            case Holdable.WateringCan:
                wateringCan.GetComponent<SpriteRenderer>().enabled = true;
                holdSword.GetComponent<SpriteRenderer>().enabled = false;
                watering();
                break;
            default:
                wateringCan.GetComponent<SpriteRenderer>().enabled = false;
                holdSword.GetComponent<SpriteRenderer>().enabled = false;
                break;
        }
    }
    void watering()
    {
        switch (face)
        {
            case 1:
                wateringCan.transform.position = new Vector3(player.transform.position.x - 0.38f, player.transform.position.y + 0.007f, 0);
                wateringCan.transform.localScale = new Vector3(1f, 1f, 1f);
                break;

            case 2:
                wateringCan.transform.position = new Vector3(player.transform.position.x+0.38f, player.transform.position.y +0.007f, 0);
                wateringCan.transform.localScale = new Vector3(-1f,1f,1f);
                break;
        }
        if (Input.GetKey(KeyCode.X) )
        {
            player.GetComponent<Player>().canMove = false;
            wateringCanAnim.SetBool("IsWatering",true);

            //Generate Water Particle
            float particleSpeedUp = 25f;
            float particleSpeed = 100f;
            float particleX = 0.5f;
            GameObject particle;
            switch (face)
            {
                case 1:
                    particleX = -0.5f;
                    break;
                case 2:
                    particleX = 0.5f;
                    break;
            }
            spCounter+=Time.deltaTime*1;
            if (spCounter> waterInterval)
            {
                spCounter = 0;
                //Modifu "WaterParticle_SP" to make watering effect
                particle = Instantiate(specialParticle, new Vector3(wateringCan.transform.position.x+ particleX, wateringCan.transform.position.y - 0.1f, transform.position.z), transform.rotation);
            }
            else
            {
                particle = Instantiate(waterParticle, new Vector3(wateringCan.transform.position.x+ particleX, wateringCan.transform.position.y - 0.1f, transform.position.z), transform.rotation);
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
            wateringCan.GetComponent<TriggerCheck>().tar_1 = wateringCan.GetComponent<TriggerCheck>().tar;
            wateringCanAnim.SetBool("IsWatering", false);
            spCounter = 0;
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
            stabRange = 1f;
            //swordAnim.SetTrigger("Stab");
            player.GetComponent<Player>().canMove = false;
            Vector3 position = new Vector3(player.transform.position.x, player.transform.position.y - stabRange, 0);
            Quaternion rotation = new Quaternion();
            string freeze = "y";

            switch (dir)
            {
                case 2:
                    position = new Vector3(player.transform.position.x, player.transform.position.y - stabRange, 0);
                    rotation = new Quaternion(0,0,1f,0);
                    freeze = "x";
                    //castDir = Vector2.down;
                    break;
                case 4:
                    position = new Vector3(player.transform.position.x - stabRange, player.transform.position.y, 0);
                    rotation = new Quaternion(0, 0, 1f, 1f);
                    freeze = "y";
                    //castDir = Vector2.left;
                    break;
                case 6:
                    position = new Vector3(player.transform.position.x + stabRange, player.transform.position.y, 0);
                    rotation = new Quaternion(0, 0, 1f, -1f);
                    freeze = "y";
                    //castDir = Vector2.right;
                    break;
                case 8:
                    position = new Vector3(player.transform.position.x, player.transform.position.y + stabRange, 0);
                    rotation = new Quaternion();
                    freeze = "x";
                    //castDir = Vector2.up;
                    break;
            }

            GameObject swd = GameObject.Instantiate(swordAttackObject, position, rotation);

            if (freeze == "y")
            {
                swd.GetComponent<Rigidbody2D>().constraints= RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionY;
            }
            else
            {
                swd.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
            }

            //GameObject tar = sword.GetComponent<TriggerCheck>().tar_1;
            /*if (tar != null)
            {
                Debug.Log(tar.name);
                if (tar.CompareTag("Wall"))
                {
                    stabRange = 1.035f;
                }
                if (tar.GetComponent<Breakable>())
                {
                    tar.GetComponent<Breakable>().health--;

                }
                //Do something with tar
                sword.GetComponent<TriggerCheck>().tar_1 = null;
            }*/
        }
        /*else
        {

            //sword.GetComponent<TriggerCheck>().tar_1 = sword.GetComponent<TriggerCheck>().tar;

        }*/

        /*if (swordAnim.GetCurrentAnimatorStateInfo(0).IsName("Sword_Attack"))
        {
            holdSword.GetComponent<SpriteRenderer>().enabled = false;
            player.GetComponent<Player>().canMove = false;
        }
        else
        {
            holdSword.GetComponent<SpriteRenderer>().enabled = true;
            player.GetComponent<Player>().canMove = true;
        }*/

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
        /*switch (dir)
        {
            case 2:
                //sword.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - stabRange, 0);
                //sword.transform.eulerAngles = new Vector3(0, 0, 180f);
                //castDir = Vector2.down;
                break;
            case 4:
                //sword.transform.position = new Vector3(player.transform.position.x - stabRange, player.transform.position.y, 0);
                //sword.transform.eulerAngles = new Vector3(0, 0, 90f);
                //castDir = Vector2.left;
                break;
            case 6:
                //sword.transform.position = new Vector3(player.transform.position.x + stabRange, player.transform.position.y, 0);
                //sword.transform.eulerAngles = new Vector3(0, 0, -90f);
                //castDir = Vector2.right;
                break;
            case 8:
                //sword.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + stabRange, 0);
                //sword.transform.eulerAngles = new Vector3(0, 0, 0f);
                //castDir = Vector2.up;
                break;
        }*/
       
    }
}

   