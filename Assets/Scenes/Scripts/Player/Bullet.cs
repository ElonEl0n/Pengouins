using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect;
    
    
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
        Physics2D.IgnoreLayerCollision(2, 8);

    }

    void OnTriggerEnter2D(Collider2D hitInfo)

    {
        
        EnemyHealth enemy = hitInfo.GetComponent<EnemyHealth>();

        if(enemy != null)
        {
            enemy.TakeDamage(20);
        }

        if (hitInfo.tag == "Enemy" || hitInfo.tag == "Ground")

        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }


       


    }

    
}
