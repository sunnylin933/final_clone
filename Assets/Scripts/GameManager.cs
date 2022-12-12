using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int gameState = 0;
    public static int crab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if(crab >= 5)
        {
            gameState = 1;
            Debug.Log(gameState);
        }
        
    }
}
