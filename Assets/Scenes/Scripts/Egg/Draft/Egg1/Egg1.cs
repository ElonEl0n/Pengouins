using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg1 : MonoBehaviour
{
    public int eggHealth;
    public int eggHealthEvolve = 20;
    public GameObject Egg2;
    public Evolution2 evolution;




    void Start()
    {
        evolution = GetComponentInChildren<Evolution2>();

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
        Instantiate(Egg2, transform.position, transform.rotation);
        Destroy(gameObject);
    }


}
