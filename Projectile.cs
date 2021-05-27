using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject impactEffect;
    
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * projectileSpeed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        var delay = 1;
        var enemyComponent = collision.gameObject.GetComponent<Enemy>();
        if(collision.tag == "Wall")
        {
            
            
            var ex = Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
           
            Destroy(ex,delay);
        }

        if(enemyComponent != null)
        {
            enemyComponent.Damaged(40);
            var ex = Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(ex, delay);
        }
    }

}
