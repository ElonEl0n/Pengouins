using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimPoint : MonoBehaviour
{
    //For mouse controls
    public Camera cam;
    Vector2 mousePos;

    //For joystick controls
    public float aimVertical;// input
    public float aimHorizontal;// input
    public float aimAngle;
    public float aimOffset;
    public float aimRadius;
    Vector2 position;

    public PlayerAim playerAim;
    public PlayerController2D player;
   


    public Transform returnA;
    public Transform returnB;
    Transform aimReturn;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
        aimReturn = returnA;

        player = GetComponentInParent<PlayerController2D>();

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //input joystick

        aimHorizontal  = Input.GetAxis("RightStickHorizontal")*aimRadius; //x
        aimVertical = Input.GetAxis("RightStickVertical")*aimRadius; //y

        Vector2 input = new Vector2(aimHorizontal, aimVertical);

        float magnitude = Mathf.Min(aimRadius, input.magnitude);

        
        aimAngle = Mathf.Atan2(aimVertical, aimHorizontal) * Mathf.Rad2Deg; //ok

        playerAim.currentAngle = aimAngle;

        position = new Vector2(magnitude *Mathf.Cos(aimAngle*Mathf.Deg2Rad), magnitude *Mathf.Sin(aimAngle*Mathf.Deg2Rad));


        //switch aimReturns
        //link with playerAim and to playerController to pass the angle and

        // flip the character effectively

        if (/*rb2d.velocity.x < -.01 && (facingRight) || */!(player.facingRight))
        {

            //add correct angle
        }








    }

    private void FixedUpdate()
    {
        transform.localPosition = position;
        //transform.position = mousePos; 
        //mouse control as a coroutine
                                       //if (Mathf.Approximately(aimVertical, 0) && Mathf.Approximately(aimHorizontal, 0))
                                       //{
                                       //    transform.position = aimReturn.position;
                                       //}
                                       //if (!Mathf.Approximately(aimVertical, 0) || !Mathf.Approximately(aimHorizontal, 0))
                                       //{
                                       //    //Stop mouse control coroutine


        //    //transform.position = new Vector2(playerPos.x + lookDirClamped.x,playerPos.y+lookDirClamped.y)*-1;
        //    transform.position = aimPos;
        //}
    }

    public static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

}
