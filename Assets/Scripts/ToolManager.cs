using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolManager : MonoBehaviour
{
    public List<ToolManagerObject> Tools;
    public GameObject p;
    Player player;
    public Player_UsingHoldItem holdItem;
    public int savePointID = 0;
    void Start()
    {
        player = p.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ToolManangerTrigger()
    {
        ToolManagerObject.tags target= ToolManagerObject.tags.None;
        
        switch (holdItem.hold)
        {
            case Player_UsingHoldItem.Holdable.Sword:
                    target = ToolManagerObject.tags.Sword;
                break;
            case Player_UsingHoldItem.Holdable.WateringCan:
                    target = ToolManagerObject.tags.WateringCan;
                break;
        }

        foreach (ToolManagerObject obj in Tools)
        {

            if (obj.tag != target)
            {
                player.inventory.Remove(obj.info);
                Vector3 pos = new Vector3(0, 0, 0);
                float f;
                if (player.face ==1)
                {
                    f = -1f;
                }
                else
                {
                    f = 1f;
                }
                if (player.hit_x)
                {
                    pos += new Vector3(-1f*f,0,0);
                }
                else
                {
                    pos += new Vector3(1f*f, 0, 0);

                }
                if (player.dir == 2)
                {
                    f = -1f;
                }
                else if(player.dir==8){
                    f = 1f;
                }
                if (player.hit_y)
                {
                    pos += new Vector3(0, -1f*f, 0);
                }
                else
                {
                    pos += new Vector3(0, 1f*f, 0);

                }
                switch (obj.tag)
                {
                    case ToolManagerObject.tags.Sword:
                        if (player.canAttack)
                        {
                            Instantiate(obj.pickableObject, p.transform.position+pos, Quaternion.identity);
                        }
                        break;

                    case ToolManagerObject.tags.WateringCan:
                        if (player.canWater)
                        {
                            Instantiate(obj.pickableObject, p.transform.position+pos, Quaternion.identity);
                        }
                        break;
                }
            }
        }

    }
}
