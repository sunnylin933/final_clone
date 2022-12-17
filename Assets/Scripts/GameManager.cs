using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static int gameState = -1;
    public static int crab = 0;
    public Timer timer;
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(gameState == 0)
        {
            
        }
       if(crab >= 5)
        {
            gameState = 1;
            Debug.Log(gameState);
            player.canPush = true;
        }
        
    }
}
