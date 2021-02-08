using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg2 : MonoBehaviour
{
    public int eggHealth;
    public int eggHealthEvolve = 20;
    public GameObject Egg3;
    public Evolution3 evolution;




    void Start()
    {
        evolution = GetComponentInChildren<Evolution3>();

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
        Instantiate(Egg3, transform.position, transform.rotation);
        Destroy(gameObject);
    }

}
