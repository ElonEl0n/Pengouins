using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnowballAttack : MonoBehaviour
{
    public Transform target;
    public Transform ejectionPoint;
    
    public GameObject snowballPrefab;
    public Snowball snowball;
    public Patrol patrol;
    public Animator animator;
    public BearAttack bearAttack;
    // Start is called before the first frame update

    private void Start()
    {
        animator = GetComponent<Animator>();
        patrol = GetComponentInParent<Patrol>();
        bearAttack = GetComponentInParent<BearAttack>();
    }
    // Update is called once per frame
    public void Attack()
    {
        animator.Play("Bear_Attack");
        bearAttack.launchTimer = true;
    }

    public void LaunchSnowball(string message)
    {
        

        if (message.Equals("LaunchSnowball"))
        {
            Debug.DrawLine(ejectionPoint.position, target.position);

            Quaternion rotation = Quaternion.identity;
            Debug.Log("snowball is launched");

            var ball = Instantiate(snowballPrefab, ejectionPoint.position, rotation) as GameObject;
            Snowball sb = ball.GetComponent<Snowball>();
            sb.aimDir = target.position - ejectionPoint.position;
            //launch countdown at the end of the animation
            //check if countdown is 0 before launching a new snowball
        }

    }

    public void EndSnowballAttack(string message)
    {
        if (message.Equals("End"))
        {
            patrol.canPatrol = true;
            animator.Play("Bear_Run");
            bearAttack.canAttack = false;
            
        }
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;

    }


    //locktargettimer: during the timer, the bear locks the target
    //at the end of the timer the bear throws the snowball towards the target

  

}
