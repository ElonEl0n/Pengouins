using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private Animator UIAnimator;
    private SpriteRenderer UIsr;
    // Start is called before the first frame update
    void Awake()
    {
        UIAnimator = GetComponent<Animator>();
        UIsr = GetComponent<SpriteRenderer>();
        UIsr.enabled = false;
    }

    public void DisplayNoFish()
    {
        UIsr.enabled = true;
        UIAnimator.Play("UI_No_Fish");
    }

    public void UnshowUI()
    {
        UIsr.enabled = false;
        
        UIAnimator.Play("New State");
    }

  

}
