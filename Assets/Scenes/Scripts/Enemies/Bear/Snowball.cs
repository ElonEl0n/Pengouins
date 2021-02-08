using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{

    //health
    //hit effect
    //collapse effect
    //dir

    public float speed = 20f;
    public Rigidbody2D rb;
    public GameObject impactEffect; //particle system
    public SnowballAttack snowballAttack;
    

    public float lifeTime;
    public bool toMelt;


    public Vector2 aimDir;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        rb.AddForce(aimDir * speed);
        
        toMelt = false;
        Mathf.Clamp(lifeTime, 0, lifeTime);
        


        Physics2D.IgnoreLayerCollision(12, 12);
    }

    private void FixedUpdate()
    {
        lifeTime -= Time.fixedDeltaTime;

        if (lifeTime < 0.1)
        {
            toMelt = true;
        }
    }

    //Hit behaviour
    //collapse if hit the player of after some time

    void OnCollisionEnter2D(Collision2D col)

    {

        if (col.gameObject.layer == LayerMask.NameToLayer("Player"))

        {
            //Instantiate(impactEffect, transform.position, transform.rotation);
            Melt();
            Destroy(gameObject);

        }
        else if (toMelt && (col.gameObject.layer == LayerMask.NameToLayer("Ground")) || col.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            Melt();
            Destroy(gameObject);
        }

    }

    public void Melt()
    {
        GameObject snowPuff = Instantiate(impactEffect, transform.position, Quaternion.identity);
        ParticleSystem melt = snowPuff.GetComponent<ParticleSystem>();
        melt.Play();
        float totalDuration = melt.main.duration;
        Destroy(snowPuff, totalDuration);
    }
}

