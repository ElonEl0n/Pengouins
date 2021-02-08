using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbatrossEgg : MonoBehaviour
{
    
    public GameObject impactEffect; //particle system
    
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    private float totalDuration;
    [SerializeField] public Transform ejectionPoint;

    // Start is called before the first frame update
    void Start()
    {
        
        Physics2D.IgnoreLayerCollision(12, 12);
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.layer == LayerMask.NameToLayer("Player") ||
            (col.gameObject.layer == LayerMask.NameToLayer("Ground")) || 
            col.gameObject.layer == LayerMask.NameToLayer("Water"))
        {
            //Instantiate(impactEffect, transform.position, transform.rotation);
            Debris();
            rb.isKinematic = true;
            sr.enabled = false;
            Destroy(gameObject, totalDuration);
            //Destroy(gameObject);
        }

    }

    private void Debris()
    {
        GameObject debris = Instantiate(impactEffect, ejectionPoint.position, Quaternion.identity);
        ParticleSystem ps = debris.GetComponent<ParticleSystem>();
        ps.Play();
        totalDuration = ps.main.duration;
        Destroy(debris, totalDuration);
    }

}
