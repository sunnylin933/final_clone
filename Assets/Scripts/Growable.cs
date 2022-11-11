using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growable : MonoBehaviour
{
    public int toGrow;
    public int counter = 0;


    private void Update()
    {
        if(counter == toGrow)
        {
            Debug.Log("success");
        }
    }

}
