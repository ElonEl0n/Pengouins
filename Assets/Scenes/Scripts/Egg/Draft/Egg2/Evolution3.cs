using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution3 : MonoBehaviour
{

    Animator anim;
    Egg2 egg2;

    private void Start()
    {
        anim = GetComponent<Animator>();
        egg2 = GetComponentInParent<Egg2>();
    }

    public void Evolve()
    {
        anim.Play("2to3");
    }

    public void EvolutionIsDone(string message)
    {
        if (message.Equals("EvolutionIsDone"))
        {
            egg2.ChangeForm();
        }
    }
}
