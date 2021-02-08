using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInvincibility : MonoBehaviour
{

    private float temporarInvincibilityTime;
    public bool launch;
    public bool isInvincible;
    public bool timerEnded;
    public PlayerDamage playerDamage;
    public SpriteRenderer sr;
    public float flashRate;
    private Coroutine flashRoutine = null;

    private void Start()
    {
        isInvincible = false;
        timerEnded = false;
        launch = false;
        playerDamage = GetComponent<PlayerDamage>();
        sr = GetComponentInChildren<SpriteRenderer>();

    }

    public void LaunchTimer(float time)
    {
        launch = true;
        temporarInvincibilityTime = time;

    }


    public void FixedUpdate()
    {
        if (launch)
        {
            isInvincible = true;
            playerDamage.canDie = false;
            // blink
            flashRoutine = StartCoroutine(Flash(sr, flashRate));
           
           temporarInvincibilityTime -= Time.deltaTime;

            if (temporarInvincibilityTime <= 0.0f)
            {
                StopAllCoroutines();
                //StopCoroutine(flashRoutine);
                sr.enabled = true;
                
                isInvincible = false;
                playerDamage.canDie = true;
                launch = false;
                temporarInvincibilityTime = 0f;
            }
        }

     

    }


    IEnumerator Flash(SpriteRenderer sr, float flashRate)
    {
        float time = 1 / flashRate;
        
        if (sr.enabled)
        {
            sr.enabled = false;
        }

        else if (!(sr.enabled))
        {
            sr.enabled = true;
        }
        yield return new WaitForSeconds(time);
        StartCoroutine(Flash(sr, flashRate));

    }

}
