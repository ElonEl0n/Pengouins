using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    public float eggHealth;
    public float eggHealthEvolve = 20;
    public GameObject NextEgg;
    public GameObject PreviousEgg;
    public Evolution evolution;
    public PlayerLayEgg playerLayEgg;
    public bool isChangingForm;

    

    //Continuous "cooldown" logic
    public float cooldownUnit;
    public float cooldownSpeed;
    public float warningTime; //warning time before regression occurrs

    //UI
    public FishBar bar;
    public Timer timer;
    






    void Start()
    {
        evolution = GetComponentInChildren<Evolution>();
        bar = GameObject.FindGameObjectWithTag("MainUI").GetComponentInChildren<FishBar>();
        bar.SetMaxFish(eggHealthEvolve);
        timer = bar.GetComponentInChildren<Timer>();
        timer.initialTimerValue = warningTime;





    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ContinuousCooldown();

        //Evolve check
        if (eggHealth >= eggHealthEvolve)
        {
            float delta = eggHealth - eggHealthEvolve;
           
            evolution.Evolve(delta);
            isChangingForm = true;
            

        }

        if (eggHealth>0)
        {
            evolution.StopCoroutine("Regress");
            //Stop UI countdown
            timer.launch = false;
        }

        //Regress check
        if (eggHealth==0f && bar.currentState !=0)
        {
            evolution.StartCoroutine("Regress", warningTime);




            //start UI countdown





        }
        //current and next state --
        //...
    }

    public void ChangeForm(bool evolve, float startingHealth)
    {
        if (evolve)
        {

            bar.ChangeImages(bar.currentState + 1, bar.nextState + 1);
            bar.currentState++;
            bar.nextState++;
            GameObject nextEgg = Instantiate(NextEgg, transform.position, transform.rotation);
            
            //timer.initialTimerValue = nextEgg.GetComponent<Egg>().warningTime;
            nextEgg.GetComponent<Egg>().eggHealth = startingHealth;
            nextEgg.GetComponent<Egg>().playerLayEgg = playerLayEgg;
            playerLayEgg.linkedEgg = nextEgg;
        }
        
        else if (!evolve)

        {
            bar.ChangeImages(bar.currentState -1, bar.nextState - 1);
            bar.currentState--;
            bar.nextState--;
            GameObject previousEgg = Instantiate(PreviousEgg, transform.position, transform.rotation);
            
            //timer.initialTimerValue = previousEgg.GetComponent<Egg>().warningTime;
            float var = previousEgg.GetComponent<Egg>().eggHealthEvolve;
            previousEgg.GetComponent<Egg>().eggHealth = var - 0.001f;
            previousEgg.GetComponent<Egg>().playerLayEgg = playerLayEgg;
            playerLayEgg.linkedEgg = previousEgg;
        }


        Destroy(gameObject);
    }

    public void ContinuousCooldown()
    {
        bar.SetFish(eggHealth);


        if (eggHealth > 0 && !isChangingForm)
        {

            eggHealth -= cooldownUnit * (eggHealthEvolve / 100) * (cooldownSpeed) * Time.deltaTime;



        }
        else if (eggHealth<0)
        {
            eggHealth = 0;
        }





    }
}
