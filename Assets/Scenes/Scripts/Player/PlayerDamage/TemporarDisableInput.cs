using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemporarDisableInput : MonoBehaviour
{
    private float temporarDisableTime;
    public bool launch;
    public bool timerEnded;
    public PlayerInput playerInput;
    public PlayerDamage playerDamage;
    

    private void Start()
    {

        timerEnded = false;
        launch = false;
        playerInput = GetComponent<PlayerInput>();
        playerDamage = GetComponent<PlayerDamage>();
       

    }

    public void LaunchTimer(float time)
    {
        launch = true;
        temporarDisableTime = time;
    }


    public void FixedUpdate()
    {
        if (launch)
        {
            playerInput.openInput = false;

            temporarDisableTime -= Time.deltaTime;

            if (temporarDisableTime <= 0.0f)
            {
                playerDamage.isHit = false;
                playerInput.openInput = true;
                launch = false;
                
            }
        }



    }
}
