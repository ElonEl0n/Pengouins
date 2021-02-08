using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Jobs;

public class PlayerController2D : MonoBehaviour
{
    public Animator animator;
    public Rigidbody2D rb2d;
    
    public float jumpSpeed = 5f;

    public float runSpeed = 3f;
    public bool facingRight = true;

    public bool isGrounded;
    public bool isSwimming;
    public string waterTag = "";

    public PlayerInput playerInput;
    
    public PlayerAim playerAim;
    [SerializeField]
    Transform groundCheckL = null;
    [SerializeField]
    Transform groundCheckR = null;
    public float groundCheckRadius;
    public float waterGravitySlower = .5f;
  
    public float waterJumpSpeedSlower = .5f;
    public float waterMovementSlower = .8f;
    
    private bool waterCooldown = false;
    public float cooldownTime = 1f;
    public LayerMask Ground;

    public PlayerLayEgg playerLayEgg;
    public bool isLayingEgg;
    public bool onLayZone;

    public PlayerDamage playerDamage;
     






    // Start is called before the first frame update
    void Start()
    {
        //Map the previous properties to the components of the Object
        animator = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        
        playerLayEgg = GetComponentInChildren<PlayerLayEgg>();
        playerAim = GetComponentInChildren<PlayerAim>();
        
        playerInput = GetComponent<PlayerInput>();
        onLayZone = false;
        playerDamage = GetComponent<PlayerDamage>();
        


    }

    void ResetCooldown()
    {
        waterCooldown = false;
    } //water jump cooldown
    


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(waterTag))
        {
            isSwimming = true;
            rb2d.gravityScale = 1.2f;
            rb2d.drag = 3f;
        }
        
    } //water enter detection

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(waterTag))
        {
            isSwimming = false;
            rb2d.gravityScale = 3f;
            rb2d.drag = 0f;
        }

    } //water exit detection

   
  void Flip (Transform transform)
    {
        transform.Rotate(0f, 180f, 0f);
        facingRight = !(facingRight);
    }

   


    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckL.position, groundCheckRadius, Ground) 
            || Physics2D.OverlapCircle(groundCheckR.position, groundCheckRadius, Ground); //Groundcheck


     
        // Flip the animation
        if (/*rb2d.velocity.x > 0.01 && (!(facingRight)) ||*/ 
            -85f <= Mathf.Round(playerAim.currentAngle) && Mathf.Round(playerAim.currentAngle) <= 85f && (!(facingRight)))
        {
            Flip(transform);
        }
        else if (/*rb2d.velocity.x < -.01 && (facingRight) || */  
            (-180f < Mathf.Round(playerAim.currentAngle) && Mathf.Round(playerAim.currentAngle) < -95f) && (facingRight)
            ||
            (95f < Mathf.Round(playerAim.currentAngle) && Mathf.Round(playerAim.currentAngle) < 180f) && (facingRight))
        {
            Flip(transform);
        }

        if (playerDamage.isHit)
        {
            animator.Play("Player_Damage");
            
        }

        

            //Movement under water
            if (isSwimming)
            {
            rb2d.AddForce(transform.up * rb2d.mass * waterGravitySlower); //Slows the fall of the player no matter the state

            if (!playerDamage.isHit)
            {
                animator.Play("Player_Jump"); //Swim animation = Jump animation

                if (playerInput.m_jump) //Swim animation = Restart the jump animation
                {


                    if (waterCooldown == false)
                    {
                        Invoke("ResetCooldown", cooldownTime);

                        rb2d.AddForce(transform.up * jumpSpeed / Time.deltaTime);

                        animator.Play("Player_Jump", -1, 0);
                        waterCooldown = true;
                    }

                    else if (waterCooldown == true)
                    {
                        return;
                    }

                }
                if (playerInput.m_right) //Swim to the right
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x * runSpeed, rb2d.velocity.y);

                }
                else if (playerInput.m_left)
                {
                    rb2d.velocity = new Vector2(rb2d.velocity.x * -runSpeed, rb2d.velocity.y);

                }
            }
            }
            


            if (playerInput.m_right)
            {
                rb2d.velocity = new Vector2(runSpeed, rb2d.velocity.y);
                if (isGrounded)
                {
                    animator.Play("Player_Run");
                }

            }

            else if (playerInput.m_left)
            {
                rb2d.velocity = new Vector2(-runSpeed, rb2d.velocity.y);
                if (isGrounded)
                {
                    animator.Play("Player_Run");
                }

            }
            else
            {
            if (isGrounded && (!(isLayingEgg)) && !playerDamage.isHit) 
                {
                    animator.Play("Player_Idle");
                }

            }

            if (playerInput.m_jump && isGrounded && (!(isSwimming))) //(!(isSwimming) prevents to jump normally when touching bottom of the water 
            {
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpSpeed);
                animator.Play("Player_Jump");
            }
            if (!(isGrounded) && !isSwimming)
            {
                animator.Play("Player_Jump");
            }


            //Laying Egg input
            if ((isGrounded && playerInput.m_layEgg) && !playerLayEgg.eggHasBeenLaid && onLayZone)
            {
                isLayingEgg = true;
                playerLayEgg.Lay();

            }
            else if ((isGrounded && playerInput.m_layEgg) && playerLayEgg.eggHasBeenLaid && onLayZone)
            {
                isLayingEgg = true;
                playerLayEgg.Feed();
            }

            else
            {
                isLayingEgg = false;
                playerLayEgg.chargeTime = 0f;

            }
        
        
    }
        
        

    }

    


    


