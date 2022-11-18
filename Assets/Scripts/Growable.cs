using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Growable : MonoBehaviour
{
    public int toGrow;
    public int counter = 0;
    public GameObject reward;


    private void Update()
    {
        if(counter == toGrow)
        {
            var tagName = this.gameObject.tag;
            switch (tagName)
            {
                case "Sprout":
                    Instantiate(reward, this.transform.position, reward.transform.rotation);
                    Destroy(this.gameObject);
                    break;
            }
        }
    }

}
