using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPoint : MonoBehaviour
{
    //For mouse controls
    public Camera cam;
    Vector2 mousePos;

    //For joystick controls
    private float aimVertical;// input
    private float aimHorizontal;// input
    public float aimAngle;
   
    public float aimRadius;
    Vector2 position;

    public PlayerAim playerAim;
    public PlayerController2D player;



    public Transform returnA; //right 
    public Transform returnB; //left
   public Transform aimReturn; //where does the aimpoint need to stay when no aiming input.



    // Start is called before the first frame update
    void Start()
    {
        //transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
        aimReturn = returnA;

        player = GetComponentInParent<PlayerController2D>();

    }

    // Update is called once per frame
    void Update()
    {
        //input mouse 
        //needs to be active only when the mouse is on screen 
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //input joystick

        aimHorizontal = Input.GetAxis("RightStickHorizontal") * aimRadius; //x
        aimVertical = Input.GetAxis("RightStickVertical") * aimRadius; //y

        Vector2 input = new Vector2(aimHorizontal, aimVertical); //gather input into one variable

        float magnitude = Mathf.Min(aimRadius, input.magnitude); //calculate the magnitude depending on the input. Prevent from being a square.


        aimAngle = Mathf.Atan2(aimVertical, aimHorizontal) * Mathf.Rad2Deg; //coverts coordinates into an angle
        
       
        

        

        float centerX = player.transform.position.x; //keep track of the center (the player) position. To offset
        float centerY = player.transform.position.y;

        position = new Vector2(magnitude * Mathf.Cos(aimAngle * Mathf.Deg2Rad) + centerX, magnitude * Mathf.Sin(aimAngle * Mathf.Deg2Rad) + centerY);


        //switch aimReturns


        if (/*rb2d.velocity.x < -.01 && (facingRight) || */!(player.facingRight))
        {
            aimReturn = returnB;
        }
        else
        {
            aimReturn = returnA;
        }








    }

    private void FixedUpdate()
    {
        
        //transform.position = mousePos; 
        //mouse control as a coroutine
        if (!Mathf.Approximately(aimVertical, 0) || !Mathf.Approximately(aimHorizontal, 0))
        {
            transform.position = position;
            playerAim.currentAngle = aimAngle; //pass the angle to the aiming logic
        }
        else 
        {
            transform.position = aimReturn.position;
            Vector3 dir = aimReturn.position - player.transform.position;
            playerAim.currentAngle = GetAngleFromVectorFloat(dir);
        }

    }
        public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;

    }
}
