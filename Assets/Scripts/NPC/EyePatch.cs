using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EyePatch : MonoBehaviour
{
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    private int index;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Sword")
        {
            Debug.Log("sadf");
            var npcScript = this.gameObject.GetComponent<NPC>();
            npcScript.StopAllCoroutines();
            npcScript.zeroText();
            npcScript.index = 1;
            dialoguePanel.SetActive(true);
            npcScript.StartCoroutine(npcScript.Typing());
        }
    }
}
