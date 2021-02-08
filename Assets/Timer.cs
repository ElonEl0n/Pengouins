using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI text;
    public float initialTimerValue;
    public float timerValue;
    
    public bool launch;
    

    // Start is called before the first frame update
    void Start()
    {
        launch = false;
        text = GetComponent<TextMeshProUGUI>();
        //timerValue = initialTimerValue;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (launch)
        {
            
            timerValue -= Time.fixedDeltaTime;
            
            //string minutes = ((int)t / 60).ToString();
            string seconds = timerValue.ToString("f2");
            text.text = seconds;

            

        }
        else
        {
            text.text = "";
            timerValue = initialTimerValue;
        }
        if (timerValue <= 0f)
        {
            
            launch = false;
            
            
            
        }

        
    }

  
    

}
