using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAttackObject : MonoBehaviour
{
    public float stayTime = 1f;
    public int damage = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyAfterPlayingAnim());
    }

    private IEnumerator DestroyAfterPlayingAnim()
    {
        yield return new WaitForSeconds(stayTime);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision!=null)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector3(0,0,0);
            if (collision.gameObject.GetComponent<Breakable>())
            {
                collision.gameObject.GetComponent<Breakable>().health -= damage;
            }
           
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Enemy>())
        {
            collision.gameObject.GetComponent<Enemy>().health -= damage;
        }
    }
}
