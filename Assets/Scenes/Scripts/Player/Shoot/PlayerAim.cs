using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public Transform firePoint;
    public Camera cam;
    public float currentAngle;
   
    public PlayerController2D player;

    public Vector3 mousePos;


    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    // Update is called once per frame
    void Update()
    {

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

    }

    private void FixedUpdate()
    {
        Vector2 lookDir = (mousePos - firePoint.position).normalized;
        
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        currentAngle = angle;
        firePoint.eulerAngles = new Vector3 (0f,0f,currentAngle);
        
        

        if (/*rb2d.velocity.x < -.01 && (facingRight) || */!(player.facingRight))
        {
            
            firePoint.Rotate(180f, 0f, 0f);
        }

    }

}
