using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evolution4 : MonoBehaviour
{
    Animator anim;
    Egg3 egg3;

    private void Start()
    {
        anim = GetComponent<Animator>();
        egg3 = GetComponentInParent<Egg3>();
    }

    public void Evolve()
    {
        anim.Play("3to4");
    }

    public void EvolutionIsDone(string message)
    {
        if (message.Equals("EvolutionIsDone"))
        {
            egg3.ChangeForm();
        }
    }
}
