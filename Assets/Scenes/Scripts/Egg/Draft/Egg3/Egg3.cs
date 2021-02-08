using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg3 : MonoBehaviour
{
    public int eggHealth;
    public int eggHealthEvolve = 20;
    public GameObject Egg4;
    public Evolution4 evolution;




    void Start()
    {
        evolution = GetComponentInChildren<Evolution4>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (eggHealth == eggHealthEvolve)
        {
            evolution.Evolve();

        }
    }

    public void ChangeForm()
    {
        Instantiate(Egg4, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
