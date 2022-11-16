using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    //I use Player_UsingHoldItem to detect this
    public int health;


    private void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }



}
