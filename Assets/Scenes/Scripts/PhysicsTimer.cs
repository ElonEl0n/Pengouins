using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTimer : MonoBehaviour
{
   
    public float targetTime1;
    public bool launch1;
    public bool timer1Ended;
    public float targetTime2;
    public bool launch2;
    public bool timer2Ended;

    private void Awake()
    {
      
        timer1Ended = false;
        timer2Ended = false;
        launch1 = false;
        launch2 = false;

    }

    public void LaunchTimer1(float time)
    {
        launch1 = true;
        targetTime1 = time;

    }

    public void LaunchTimer2(float time)
    {
        launch2 = true;
        targetTime2 = time;
    }


    public void FixedUpdate()
    {
        if (launch1)
        {
            timer1Ended = false;
            targetTime1 -= Time.deltaTime;

            if (targetTime1 <= 0.0f)
            {
                timer1Ended = true;
                launch1 = false;
                targetTime1 = 0f;
            }
        }

        if (launch2)
        {
            timer2Ended = false;
            targetTime2 -= Time.deltaTime;

            if (targetTime2 <= 0.0f)
            {
                timer2Ended = true;
                launch1 = false;
                targetTime2 = 0f;
            }
        }

    }
}
