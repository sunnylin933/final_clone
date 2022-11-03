using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Store information of each item
 */
[CreateAssetMenu(menuName = "Item")]
public class ItemInfo : ScriptableObject
{
    public string name;
    public Sprite sprite;
    public string information;
    public string unlockAbility;
}
