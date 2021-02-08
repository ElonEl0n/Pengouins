using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayEgg : MonoBehaviour
{
    public PlayerController2D player;
    public PlayerScore playerScore;
    public ParticleSystem ps;
    public PlayerUI playerUI;
    public Animator animator;
   
    public Transform layPoint;
    public GameObject eggPrefab;
    public bool isLayPointRight;
    public bool eggHasBeenLaid;
    public float feedRate;
    public float chargeTime = 0f;

    public GameObject layZone;
    public GameObject linkedEgg;

    public FishBar bar; 


    void Start()
    {
        player = GetComponentInParent<PlayerController2D>();
        playerScore = GetComponentInParent<PlayerScore>();
        animator = GetComponent<Animator>();
        playerUI = GetComponentInChildren<PlayerUI>();
        bar = GameObject.FindGameObjectWithTag("MainUI").GetComponentInChildren<FishBar>();
        
        
        
       
        ps = GetComponentInChildren<ParticleSystem>();
        eggHasBeenLaid = false;
    }

   public void Lay()
    {

        if (playerScore.score == 0)
        {
            playerUI.DisplayNoFish();
        }
        else
        {
            animator.Play("Player_Charge");
        }


    }
   
    public void EggIsLaid (string message)
    {
        if(message.Equals("EggIsLaid"))
        {
            if (!eggHasBeenLaid)
            {
                bar.gameObject.SetActive(true);
                GameObject eggLocal =  Instantiate(eggPrefab, layPoint.position, Quaternion.identity);
                linkedEgg = eggLocal;//first egg possible access by casting the instantiated gameobject.
                eggLocal.GetComponent<Egg>().playerLayEgg=this;
                // Modify the egg logic with
                // Egg script
                //Evolution script
                //int variables to keep track of each state of the egg
                
                player.isLayingEgg = false;
                eggHasBeenLaid = true;
            }
        }

    }



    public void Feed()
    {
        animator.Play("Player_Charge");
        
        chargeTime+= Time.fixedDeltaTime;

        if (chargeTime > feedRate)
        {
            //If score is 0 particle system burst 3 red cross signs
            if (playerScore.score == 0f)
            {
                print("Impossible to feed: no fish");
                playerUI.DisplayNoFish();
                
            }
            else if(playerScore.score>0)
            {
                TransferFish();
                //Transfer Fish

                chargeTime = 0f;
            }
            //else if score>0 Transfer fish
            
            

        }
        
       

    }
    
    public void TransferFish()
    {
        //For the Player: decrease the score, and ui modified (particle system: burst 1 fish, that vanishes slowly)
        playerScore.IncreaseScore(false);
        ps.Play();
        print("One fish has been transfered");


        //For the Egg: increase the health and future ui modified (particle system: burst 1 plus sign, that vanishes slowly)
        //access to egg's health
        Egg egg = linkedEgg.GetComponent<Egg>();
  egg.isChangingForm = false;
        egg.eggHealth++;
        
        

    }

    


}
