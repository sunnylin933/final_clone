using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public string[] dialogue;
    public float detectRange;
    public TextMeshProUGUI dialogueText;
    public GameObject dialoguePanel;
    public int index;
    public GameObject player;
    public bool typing;
    public Transform dialoguePosition;

    public float wordSpeed;
    public bool playerIsClose;

    // Start is called before the first frame update
    void Start()
    {
        
        if(GameManager.gameState == 1)
        {
            if(this.gameObject.name == "alligator")
            {
                dialogue[0] = "SO GLAD THOSE CRABS ARE GONE!";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if(playerIsClose == true && typing == false)
        {
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                typing = true;
                dialoguePanel.SetActive(true);
                dialoguePanel.transform.position = new Vector3(dialoguePosition.position.x, dialoguePosition.position.y, -1000);
                   
                StartCoroutine(Typing());
            }
        }
       
        
    }
    public void nextLine()
    {
        if(index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

    public void zeroText()
    {
        typing = false;
        StopAllCoroutines();
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }
    
    public void CheckDistance()
    {
        if(Mathf.Abs(Vector2.Distance(player.transform.position , this.transform.position)) > detectRange)
        {
            playerIsClose = false;
            typing = false;
            zeroText();
        }
     
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerIsClose = false;
            zeroText();
        }
    }
    
    public IEnumerator Typing()
    {

        foreach(char letter in dialogue[index].ToCharArray())
        {
            Debug.Log("ff");
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
            
        }
        
    }
}
