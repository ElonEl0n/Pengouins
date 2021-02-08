using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution1 : MonoBehaviour //GFX behaviour
{
    Animator anim;
    Egg0 egg0;

    private void Start()
    {
        anim = GetComponent<Animator>();
        egg0 = GetComponentInParent<Egg0>();
    }

    public void Evolve()
    {
        anim.Play("0to1");
    }

    public void EvolutionIsDone(string message)
    {
        if (message.Equals("EvolutionIsDone"))
        {
            egg0.ChangeForm();
        }
    }
}
