using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg0 : MonoBehaviour
{
    public int eggHealth;
    public int eggHealthEvolve = 20;
    public GameObject Egg1;
    public Evolution1 evolution;
  




    void Start()
    {
        evolution = GetComponentInChildren<Evolution1>();

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
        Instantiate(Egg1, transform.position, transform.rotation);
        Destroy(gameObject);
    }

 

}
   

