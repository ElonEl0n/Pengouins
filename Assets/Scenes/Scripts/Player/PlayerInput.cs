using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public bool m_right;
    public bool m_left;
    public bool m_layEgg;
    public bool m_jump;
    public bool m_shoot;
    public bool openInput;


    // Update is called once per frame
    private void Start()
    {
        openInput = true;
        m_right = false;
        m_left = false;
     m_layEgg = false;
     m_jump = false;
    m_shoot = false;
}

    void FixedUpdate()
    {
       if (openInput)
       {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("PadJump"))
            {
                m_jump = true;
            }
            else
            {
                m_jump = false;
            }

           if (Input.GetAxis("Horizontal")>0 || Input.GetAxis("MoveHorizontal")>0)
            {
                m_right = true;
            }
           else
            {
                m_right = false;
            }

           if (Input.GetAxis("Horizontal")<0 || Input.GetAxis("MoveHorizontal") < 0)
            {
                m_left = true;
            }
           else
            {
                m_left = false;
            }

            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey("s") || Input.GetAxis("LeftTrigger")>0)
            {
                m_layEgg = true;
            }
            else
            {
                m_layEgg = false;
            }

          if (Input.GetMouseButton(0) || Input.GetAxis("PadFire")>0)
            {
                m_shoot = true;
            }

            else
            {
           
                m_shoot = false;
            }

       }

        else if (!(openInput))
       {
           m_right = false;
            m_left = false;
           m_layEgg = false;
            m_jump = false;
           m_shoot = false;
        }


    }
}
