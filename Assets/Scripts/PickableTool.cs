using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableTool : MonoBehaviour
{
    ToolManager manager;
    Player player;
    float pickupTime = 1f;
    public enum Tools
    {
        Sword,
        WateringCan,
        Camera //Do we need camera?
    }

    public Tools ToolName;

    void Start()
    {
        manager = GameObject.Find("PickingToolManager").GetComponent<ToolManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        pickupTime -= Time.deltaTime;
        if(pickupTime < 0)
        {
            this.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player_UsingHoldItem playerHold = collision.GetComponent<Player_UsingHoldItem>();
        Player player = collision.GetComponent<Player>();
        if (playerHold)
        {
            switch (ToolName)
            {
                case Tools.Sword:
                        playerHold.hold = Player_UsingHoldItem.Holdable.Sword;
                    break;
                case Tools.WateringCan:
                        playerHold.hold = Player_UsingHoldItem.Holdable.WateringCan;
                    break;
            }
            manager.ToolManangerTrigger();
            Destroy(this.gameObject);
        }
    }

    
}
