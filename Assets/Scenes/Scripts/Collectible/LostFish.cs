using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostFish : MonoBehaviour
{

    public Vector2 ejectionDirection;
    public float ejectionForce;
    private Rigidbody2D rb2d;
 
    public float randomRadius;
    

    
    public int coinValue = 1;


    public float timerSinceSpawn = 0f;
    public float timerCoinCollection = 3f;
    public bool canCollect;
    public float timerStartFlashing = 5f;
    public float flashRate;
    public float timerCoinVanish = 7f;
    

    public SpriteRenderer spriteRenderer;

   
    void Awake()
    {
        canCollect = false;
       
    }
    
   void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        ejectionDirection = new Vector2(0 + Random.Range(-randomRadius, randomRadius),
          1 + Random.Range(-randomRadius, randomRadius)).normalized;
       

        

        rb2d.velocity = (ejectionDirection* ejectionForce);
        

       
       

//Set timer for flash logic
//Flash logic in Start(), not FixedUpdate

    }

    public void FixedUpdate()
    {
      
        timerSinceSpawn += Time.deltaTime;

        
        if(!(canCollect))
        {
            Physics2D.IgnoreLayerCollision(11, 8,true);
        }

        if (timerSinceSpawn>=timerCoinCollection)
        {
            Physics2D.IgnoreLayerCollision(11, 8, false);
            canCollect =true;
        }

        if (timerSinceSpawn >= timerStartFlashing)
        {

            StartCoroutine(Flash(spriteRenderer, flashRate));
            //Flash();
        }

        if (timerSinceSpawn >= timerCoinVanish)
        {

            Destroy(gameObject);
        }



    }

    
    
    //void OnCollisionEnter2D(Collision2D collision)
    //{
        
    //    if (timerSinceSpawn >= timerCoinCollection)
    //    {
    //        PlayerScore playerScore = collision.gameObject.GetComponent<PlayerScore>();
    //        if (playerScore.score < playerScore.coinCapacity)
    //        {
    //            playerScore.ChangeScore();
    //            Destroy(gameObject);
    //        }

    //        else if (playerScore.score == playerScore.coinCapacity)
    //        {
    //            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
    //        }
            
    //        //Physics2D.IgnoreLayerCollision(8, 0, false);


    //    }

       
    //}

        //Flash(); //call flash after x seconds
        //disable collision detection for 2 seconds to prevent immediate collection of lost coins


    IEnumerator Flash(SpriteRenderer sr, float flashRate)
    {
        float time = 1 / flashRate;
        yield return new WaitForSeconds(time);
        if (sr.enabled)
        {
            sr.enabled = false;
        }

        else if (!(sr.enabled))
        {
            sr.enabled = true;
        }
   
        StartCoroutine(Flash(sr,flashRate));

    }

    }






