using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerScore : MonoBehaviour
{
    public int startingScore;
    public int score;
    public int coinCapacity;
    private Spawner spawner;
    public ScoreManager scoreManager;
    

    void Awake()
    {
        scoreManager = GameObject.FindGameObjectWithTag("MainUI").GetComponentInChildren<ScoreManager>();
        score = startingScore;
        scoreManager.startingScore = score;
        scoreManager.coinCapacity = coinCapacity;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin") )
        {
           
            if (score> coinCapacity)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), other);//player max coin capacity
            }
            
            else if (score < coinCapacity)
            {
                 
                spawner = other.gameObject.GetComponentInParent<Spawner>();
                spawner.Reset(other.gameObject);
                IncreaseScore(true);


                //spawner.Reset(childPos,gameObject);
            }
        }


        

    }

    private void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.CompareTag("LostCoin"))
        {
           LostFish lostFish = collision.gameObject.GetComponent<LostFish>();
            //print(lostFish.canCollect);

            //if (!(lostFish.canCollect))
            //{
            //    Physics2D.IgnoreLayerCollision(0, 8, true);
            //}




            if (score < coinCapacity && lostFish.canCollect)
            {
                IncreaseScore(true);
                Destroy(collision.gameObject);

            }

            else if (score == coinCapacity)
            {
                Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
                //ignore collision with player
            }


        }
    }

    public void IncreaseScore(bool increase)
    {
        if (increase)
        {
            score++;
        }
        else if (!increase)
        {
            score--;
        }
        scoreManager.text.text = "X" + score.ToString() + "/"+ coinCapacity.ToString();
    }

    public void ResetScore()
    {
        this.score = 0;
        scoreManager.text.text = "X0" + "/" + coinCapacity.ToString();
    }
}
