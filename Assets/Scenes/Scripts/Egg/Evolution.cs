using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution : MonoBehaviour
{
    Animator anim;
    Egg egg;
    Timer timer;
    public float StartingHealth;

    
    
    private void Start()
    {
        anim = GetComponent<Animator>();
        egg = GetComponentInParent<Egg>();
        timer = egg.timer;
        
       
    }

    public void Evolve(float startingHealth)
    {
        
        anim.Play("Evolution");
        StartingHealth = startingHealth;
    }

    public IEnumerator Regress(float warningTime)
    {
        //timer.timerValue = warningTime;
        timer.launch = true;
        yield return new WaitForSeconds(warningTime);
        egg.isChangingForm = true;
        timer.launch = false;
        anim.Play("Regression");
        
    }


   

    public void EvolutionIsDone(string message)
    {
        if (message.Equals("EvolutionIsDone"))
        {
            egg.ChangeForm(true, StartingHealth);
            egg.isChangingForm = false;

        }
    }

    public void RegressionIsDone (string message)
    {
        if (message.Equals("RegressionIsDone"))
        {
            egg.ChangeForm(false, StartingHealth);
            timer.launch = false;
            egg.isChangingForm = false;
        }
    }
}
