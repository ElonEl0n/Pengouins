using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg4 : MonoBehaviour
{
    public int eggHealth;
    public int eggHealthEvolve = 20;
    public Evolution5 evolution;




    void Start()
    {
        evolution = GetComponentInChildren<Evolution5>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (eggHealth == eggHealthEvolve)
        {
            evolution.Evolve();

        }
    }

    

}
