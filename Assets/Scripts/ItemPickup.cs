using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    /*
     * General Usage: Attatch this script on an item sprite and feed a itemInfo scriptable object. When player picks up the item
     * it will automatically be added into the UI (player will be able to view what item they have) and player's inventory.
     * 
     */
    public ItemInfo itemInfo;
    // Start is called before the first frame update


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if(gameObject.name == "PickableSword")
            {
                Debug.Log("fdf");
                GameManager.gameState = 0;
            }
            var player = collision.gameObject.GetComponent<Player>();
            //add this item to UI
            //unlock abilities on player by adding them to Player Inventory
            player.inventory.Add(itemInfo);
            player.UnlockAbility();
            Destroy(gameObject);
        }
    }
}
