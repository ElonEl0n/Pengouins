using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearAttack : MonoBehaviour
{
    public float viewDistance;
    public Transform viewPoint;
    public Transform ejectionPoint;
    private Vector2 endAim;
    [SerializeField] public Patrol patrol;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] public SnowballAttack snowballAttack;

    public Transform playerSpotted;
    
    
    public float attackTime;//minimum time between two attacks
    public float attackTimeLocal;
    public bool launchTimer;
    public bool canAttack; //to wait right after snowball has been launched

    // Start is called before the first frame update
    void Start()
    {
        playerSpotted = null;
        attackTimeLocal = attackTime;
        canAttack = true;
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer(viewDistance);
       
        if (CanSeePlayer(viewDistance) && canAttack)
        {
            
            SnowballAttack(playerSpotted);
           //Debug.DrawLine(ejectionPoint.position, playerSpotted.position, Color.yellow);


        }
        

        if(launchTimer)
        {
            attackTimeLocal -= Time.deltaTime;
            if(attackTimeLocal < 0)
            {
                canAttack = true;
                launchTimer = false;
                attackTimeLocal = attackTime;
            }
        }
        


    }

    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDistance = distance;
        float angle = 350;
      
       
        if(!patrol.facingRight)
        {
           castDistance = -distance ;
            angle = 10;

        }



        Vector2 endAim = viewPoint.position + GetVectorFromAngle(angle) * castDistance;
       
        RaycastHit2D raycastHit2D = Physics2D.Linecast(viewPoint.position, endAim, layerMask);

        
        if (raycastHit2D.collider != null)
        {
            Debug.DrawLine(viewPoint.position, raycastHit2D.point, Color.blue);

            if (raycastHit2D.collider.gameObject.CompareTag("Player"))
            {
                val = true;
                playerSpotted = raycastHit2D.collider.transform;
                
                

            }
           

        }
        else
        {
            Debug.DrawLine(viewPoint.position, endAim, Color.red);
            val = false;
            
        }

        return val;
        
        

    }
    //Check player if in range
    //distance with raycast + wall interaction
    //if in range: aim always at player and launch attack
    //Attack() = stop patrol + animation + instantiate snowball + cooldown logic
    //if not in range continue patrol

   public void SnowballAttack(Transform target)
    {
        patrol.canPatrol = false;
        snowballAttack.target = target;
        snowballAttack.Attack();
        
 
        //aimdir viewpoint to playerpos
        //launch animation
        //once animation is done, instantiate snowball
        
        //snowball logic must take into account target position 
    }


    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

   

}

