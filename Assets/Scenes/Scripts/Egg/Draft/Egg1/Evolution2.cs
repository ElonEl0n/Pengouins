using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution2 : MonoBehaviour
{
 
    Animator anim;
    Egg1 egg1;

    private void Start()
    {
        anim = GetComponent<Animator>();
        egg1 = GetComponentInParent<Egg1>();
    }

    public void Evolve()
    {
        anim.Play("1to2");
    }

    public void EvolutionIsDone(string message)
    {
        if (message.Equals("EvolutionIsDone"))
        {
            egg1.ChangeForm();
        }
    }
}

