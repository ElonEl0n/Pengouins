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
    public float aimRadius;
    Vector2 aimPos;
    public float aimSensitivity; //check if necessary
    public Transform player; // check if necessary
    float playerOriginX;
    float playerOriginY;
    public Transform returnA;
    public Transform returnB;
    Transform aimReturn;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
        aimReturn = returnA;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos= cam.ScreenToWorldPoint(Input.mousePosition);
        //input joystick

        aimHorizontal = Input.GetAxis("RightStickHorizontal"); //x
        aimVertical = Input.GetAxis("RightStickVertical"); //y

        playerOriginX = player.transform.position.x;
        playerOriginY = player.transform.position.y;

        

        if(aimHorizontal>0 && aimVertical >0)
        {
            aimPos = new Vector2(Mathf.Sqrt((aimRadius * aimRadius - aimVertical * aimVertical)), 
                Mathf.Sqrt((aimRadius*aimRadius - aimHorizontal*aimHorizontal)));
            aimReturn = returnA;

        }
        if (aimHorizontal < 0 && aimVertical > 0)
        {
            aimPos = new Vector2(-Mathf.Sqrt((aimRadius * aimRadius - aimVertical * aimVertical)),
                Mathf.Sqrt((aimRadius * aimRadius - aimHorizontal * aimHorizontal)));
            aimReturn = returnB;
        }
        if (aimHorizontal < 0 && aimVertical < 0)
        {
            aimPos = new Vector2(-Mathf.Sqrt((aimRadius * aimRadius - aimVertical * aimVertical)),
                -Mathf.Sqrt((aimRadius * aimRadius - aimHorizontal * aimHorizontal)));
            aimReturn = returnB;
        }
        if(aimHorizontal > 0 && aimVertical < 0)
        {
            aimPos = new Vector2(Mathf.Sqrt((aimRadius * aimRadius - aimVertical * aimVertical)),
                -Mathf.Sqrt((aimRadius * aimRadius - aimHorizontal * aimHorizontal)));
            aimReturn = returnA;
        }



    }

    private void FixedUpdate()
    {
        //transform.position = mousePos; //mouse control as a coroutine
        if (aimVertical == 0 && aimHorizontal == 0)
        {
            transform.position = aimReturn.position;
        }
        if (aimVertical!=0 || aimHorizontal !=0)
        {
            //Stop mouse control coroutine
            transform.position = aimPos; 
        }
    }

     
}
