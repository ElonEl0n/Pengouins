using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public bool canPatrol;
    public float speed;
    public float distance;

    public bool facingRight;
    public Transform groundCheck;
    
    private Vector3 aimDir;


    

    private void Start()
    {
        Physics2D.IgnoreLayerCollision(12, 2);
        facingRight = true;
        canPatrol = true;
    }


    private void Update()
    {
       if(canPatrol)
        {
            PatrolMovement();
        }

        else if (!canPatrol)
        {
            return;
        }
        
        

       


    }
    void Flip(Transform transform)
    {
        transform.Rotate(0f, 180f, 0f);
        
    }

    void PatrolMovement()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, distance);



        if ((groundInfo.collider == false))
        {
            if (facingRight)
            {
                facingRight = false;
                Flip(transform);
                //transform.rotation = Quaternion.Euler(0, 180, 0);

            }

            else if (!(facingRight))
            {

                facingRight = true;
                Flip(transform);
                //transform.rotation = Quaternion.Euler(0,0,0);
            }

        }
    }

}
