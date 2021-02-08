using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public static PlayerController2D player;
    public GameObject fishPrefab;
    public Transform ejectionPoint;// child of player
    public float randomRadius;

    public PlayerScore score;
    

    public float playerInvincibilityTime;
    public float playerPushbackPower;
    public PlayerInput playerInput;
    public Rigidbody2D rb2d;
  
    public bool canDie;
    public float setTemporarInvincibilityTime;
    public PlayerInvincibility playerInvincibility;
    public float setTemporarDisableTime;
    public TemporarDisableInput temporarDisableInput;
    

    public bool isHit;



    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        rb2d = GetComponent<Rigidbody2D>();
        canDie = true;
        
        player = GetComponent<PlayerController2D>();

        playerInvincibility = GetComponent<PlayerInvincibility>();
        temporarDisableInput = GetComponent<TemporarDisableInput>();
        score = GetComponent<PlayerScore>();
        

        isHit = false;
        
        

    }

    private void FixedUpdate()
    {
        if(score.score>0)
        {
            canDie = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 pushBackDirection = (transform.position - collision.collider.transform.position).normalized;

        if (collision.collider.CompareTag("Enemy"))
        {
            
            if(score.score==0 && canDie)
            {
                PlayerDie();
                PushBack(pushBackDirection);
                temporarDisableInput.LaunchTimer(setTemporarDisableTime);//cut player controller input while in air
            }

            else if (score.score>0)
            {
                isHit = true;

                LooseCoin(score.score);
                PushBack(pushBackDirection);
                playerInvincibility.LaunchTimer(setTemporarInvincibilityTime); 
                temporarDisableInput.LaunchTimer(setTemporarDisableTime); 
                
            }
        }
    }


    void PlayerDie()
    {
        print("Dead");
    }

    void LooseCoin(int scor)
    {
        score.score = 0;
        score.ResetScore();   
        for (int i = 0; i <scor; i++) 
        {  
            GameObject Coin =  Instantiate(fishPrefab, ejectionPoint.position,Quaternion.identity) as GameObject; //cast the objects, prevent the modification between prefab clone

        }

        //PlayerInvincibility();

    }

    void PushBack(Vector2 direction)
    {
        float angle = GetAngleFromVectorFloat(direction);
        if ((0f< angle && angle<90f) || (270f<angle && angle<360f))
        {
            //cut control input (adjust manually the time of the input cut)
            //apply bezier curve movement towards right

        }
        else if ((90f < angle && angle < 270f))
        {
            //cut control input (adjust manually the time of the input cut)
            //apply bezier curve movement towards left
        }

        rb2d.velocity = direction * playerPushbackPower; // push back the player
        

    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;

    }



}
