using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution5 : MonoBehaviour
{
    Animator anim;
    Egg4 egg4;

    private void Start()
    {
        anim = GetComponent<Animator>();
        egg4 = GetComponentInParent<Egg4>();
    }

    public void Evolve()
    {
        anim.Play("4toVictory");
    }

   //Game Over Logic
    /*public void EvolutionIsDone(string message)
    {
        if (message.Equals("EvolutionIsDone"))
        {
            egg3.ChangeForm();
        }
    }*/
}
