using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHeat : MonoBehaviour
{
    public bool canShoot;
    
    public float heat;
    public float heatMax;
    public WeaponCooldownBar bar;

    public float cooldownUnit; //how much the weapon cools
    private float cooldownSpeed; //how fast the weapon cools
    public float cooldownSpeedBeforeOverheat; //how fast the weapon cools continuously
    public float cooldownSpeedAfterOverheat; //faster than the continuous cooldown

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        bar = GameObject.FindGameObjectWithTag("MainUI").GetComponentInChildren<WeaponCooldownBar>();
        heat = 0f;
        bar.SetMaxHeat(heatMax);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        bar.SetHeat(heat);
        

        if (heat>0)
        {
            
            heat -= cooldownUnit * (heatMax / 100) * (1 / cooldownSpeed) * Time.deltaTime;

            if (heat>heatMax)
            {
                canShoot = false;
                cooldownSpeed = cooldownSpeedAfterOverheat;
            }
            
        }

        else if (heat<=0)
        {
            heat = 0;
            canShoot = true;
            cooldownSpeed = cooldownSpeedBeforeOverheat;
        }
      

    }
}
