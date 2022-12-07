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
                switch (obj.tag)
                {
                    case ToolManagerObject.tags.Sword:
                        if (player.canAttack)
                        {
                            Instantiate(obj.pickableObject, p.transform.position+new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                        }
                        break;

                    case ToolManagerObject.tags.WateringCan:
                        if (player.canWater)
                        {
                            Instantiate(obj.pickableObject, p.transform.position+ new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                        }
                        break;
                }
            }
        }

    }
}
