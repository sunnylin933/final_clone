using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ToolManager")]
public class ToolManagerObject : ScriptableObject
{
    public enum tags
    {
        None,
        Sword,
        WateringCan,
        Camera
    }

    public tags tag;
    public ItemInfo info;
    public List<Vector2> savePosition;
    public GameObject pickableObject;
}
