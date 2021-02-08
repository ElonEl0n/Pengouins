using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySeaLion : MonoBehaviour
{
    public Rigidbody2D rb2d;
    public Transform target;
    public float chaseRadius;

    public GameObject player;
    public PlayerController2D playerController;
    //public PlayerInvincibility playerInvincibility;
    public Animator animator;
    public SpriteRenderer sr;
    public bool facingRight;

    Vector2 lastPos;
    Vector2 newPos;
    Vector2 trackVelocity;


    public float moveSpeed;

    // Start is called before the first frame 
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        sr = GetComponentInChildren<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController2D>();
        rb2d = GetComponent<Rigidbody2D>();
        target = player.transform;
    }

    void Start()
    {
        
        
        facingRight = true;
        lastPos = transform.position;
        newPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDistance();

        newPos = transform.position;
        trackVelocity = (newPos - lastPos) /Time.fixedDeltaTime;
        lastPos = newPos;
        
      
        

        if(trackVelocity.x >0 && (!facingRight))
        {   
            facingRight = true;
        }

        else if (trackVelocity.x < 0 && (facingRight))
        {
            facingRight = false;
        }

        if (!facingRight)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
       

        //Detect if the target is still underwater
    }

    //void Flip()
    //{
    //    if(sr.flipX)
    //    {
    //        sr.flipX = false;
    //    }
    //    else if (!sr.flipX)
    //    {
    //        sr.flipX = true;
    //    }
    //}

    public virtual void CheckDistance()
    {
       

            if (Vector3.Distance(transform.position, target.position) <= chaseRadius &&
            playerController.isSwimming &&
            playerController.playerInput.openInput)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
                rb2d.MovePosition(temp);
            animator.Play("SeaLion_Dash");
            
            }
        
        else if (Vector3.Distance(transform.position, target.position) > chaseRadius ||
            (!(playerController.isSwimming)) ||
            !playerController.playerInput.openInput)
        {

        }
        
    }



    
}

