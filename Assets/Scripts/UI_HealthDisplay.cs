using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HealthDisplay : MonoBehaviour
{
    int health;
    int max_health;//Min2,Max8
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Sprite empty;
    public Sprite[] spr_window;//
    public GameObject[] Hearts;
    public GameObject[] Window;
    GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        p = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        health = p.GetComponent<Player>().health;
        max_health = p.GetComponent<Player>().maxHealth;
        if (health > max_health)
        {
            health = max_health;
        }
        if (max_health > Hearts.Length)
        {
            max_health = Hearts.Length;
        }
        for(int i = 0; i < health; i++)
        {
            Hearts[i].GetComponent<Image>().sprite = fullHeart;
        }
        for (int i= health;i< max_health; i++)
        {
            Hearts[i].GetComponent<Image>().sprite = emptyHeart;
        }
        for(int i=max_health;i< Hearts.Length; i++)
        {
            Hearts[i].GetComponent<Image>().sprite = empty;
            Window[i].GetComponent<Image>().sprite = empty;
        }
        for(int i = 1; i < max_health - 1; i++)
        {
            Window[i].GetComponent<Image>().sprite = spr_window[1];
        }
        Window[max_health-1].GetComponent<Image>().sprite = spr_window[2];
    }
}
