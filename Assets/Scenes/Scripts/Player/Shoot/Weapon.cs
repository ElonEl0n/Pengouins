using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public PlayerAim playerAim;
    public PlayerController2D player;
    public PlayerInput playerInput;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Animator firePointAnimator;
    float lastFired;
    public float fireRate = 2f;
    public float shootCost = 2f;
    

    public WeaponHeat weaponHeat;


    public float recoilIntensityGround;
    public float recoilIntensityAir;


    private void Start()
    {
        playerAim = GetComponent<PlayerAim>();
        weaponHeat = GetComponent<WeaponHeat>();
        player = GetComponentInParent<PlayerController2D>();
        playerInput = GetComponentInParent<PlayerInput>();
        
        
        
        //if (cooldownSpeed==0f)
        //{
        //    cooldownSpeed = .001f;
        //}
        
        
        //if (cooldownSpeedAfterOverheat == 0f)
        //cooldownSpeedAfterOverheat = .001f;
        //cooldownSpeedBeforeOverheat = .001f;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerInput.m_shoot)
        {
            //if (weaponOverheated)
            //{
            //    print("overheat");
            //    return;//print overheat
            //}

            if (weaponHeat.canShoot)
            { 
                if (Time.time - lastFired > 1 / fireRate)
                {
                    lastFired = Time.time;
                    Shoot();
                    CinemachineShake.Instance.ShakeCamera(1.8f, .1f);

                }

                

        }
        }

  
        
    }
    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        weaponHeat.heat += shootCost;
        Recoil();
        firePointAnimator.Play("Smoke");
        
    }

    void Recoil()
    {
        Vector2 recoilTowards = (firePoint.position - playerAim.mousePos).normalized;
        if (player.isGrounded)
        {
            player.rb2d.AddForce(recoilTowards * recoilIntensityGround);
        }

        else
        {
            player.rb2d.AddForce(recoilTowards * recoilIntensityAir);
        }
        


    }

}

