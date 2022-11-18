using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerOrderManager : MonoBehaviour
{
    private Renderer mRenderer;
    private void Start()
    {
        mRenderer = GetComponent<Renderer>();
    }
    // Start is called before the first frame update
    private void LateUpdate()
    {
        /*foreach (var rend in GetComponentsInChildren<Renderer>())
        {
            rend.sortingOrder = -(int)(GetComponent<Collider2D>().bounds.min.y * 1000);
        }*/

       mRenderer.sortingOrder = -(int)(GetComponent<Collider2D>().bounds.min.y * 1000);
    }
}
