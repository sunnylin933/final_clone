using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_UsingHoldItem : MonoBehaviour
{
    public GameObject player;
    public int dir;

    private enum Holdable
    {
        None,
        Sword,
        Watering_Can,
        Camera //Do we need camera?
    }

    private Holdable hold;

    public GameObject sword;
    public Animator sword_anim;
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dir = player.GetComponent<Player>().dir;
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
            /*List<GameObject> targets = sword.GetComponent<TriggerCheck>().targets;
            foreach(GameObject o in targets)
            {
                //try to do something with o
                Debug.Log(o.name);
            }
            sword.GetComponent<TriggerCheck>().targets= new List<GameObject>();*/
            GameObject tar = sword.GetComponent<TriggerCheck>().tar;
            if (tar != null)
            {
                Debug.Log(tar.name);
            }
            //Do something with tar
        }
    }
}

   