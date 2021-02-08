using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaLionPatrol : EnemySeaLion
{
    public GameObject pathToLoad;
    public List<Transform> pathToFollow = new List<Transform>();
    public int currentPoint;
    public Transform nextWayPoint;
    public float roundingDistance;

    public float chasingSpeed;
    public float patrolSpeed;

    public EnemyDeath enemyDeath;

    private void Start()
    {
        enemyDeath = GetComponent<EnemyDeath>();
        InstantiatePatrolPoints();
    }


    public override void CheckDistance()
    {
        
            if (Vector3.Distance(transform.position, target.position) <= chaseRadius &&
            playerController.isSwimming &&
            playerController.playerInput.openInput)
            {
                Vector3 temp = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            moveSpeed = chasingSpeed;
                rb2d.MovePosition(temp);
            animator.Play("SeaLion_Dash");
            }
        
        else if (Vector3.Distance(transform.position, target.position) > chaseRadius || 
            (!(playerController.isSwimming)) ||
            !playerController.playerInput.openInput)
        {
            moveSpeed = patrolSpeed;
            animator.Play("SeaLion_Swim");
                  if (Vector3.Distance(transform.position, pathToFollow[currentPoint].position) > roundingDistance)
                  {

                Vector3 temp = Vector3.MoveTowards(transform.position, pathToFollow[currentPoint].position, moveSpeed * Time.deltaTime);
                rb2d.MovePosition(temp);
                  }
              else
                {
                ChangeGoal(); //override the CheckDistance()
                }
        }
    }

    
    //Design the path
    private void ChangeGoal()
    {
        if (currentPoint == pathToFollow.Count - 1)

        {
            currentPoint = 0;
            nextWayPoint = pathToFollow[0];
        }

        else if (currentPoint == 0)
            {
            currentPoint++;
            nextWayPoint = pathToFollow[1];
        }

        else if (currentPoint == 1)
        {
            currentPoint++;
            nextWayPoint = pathToFollow[2];
        }

        else if (currentPoint == 2)
        {
            currentPoint++;
            nextWayPoint = pathToFollow[3];
        }

       
    }

    private void InstantiatePatrolPoints()
    {

        var path = Instantiate(pathToLoad, transform.position, Quaternion.identity) as GameObject;
        enemyDeath.patrolPoints = path;
        Transform[] patrolPoints = path.GetComponentsInChildren<Transform>();//Gets also the parent object so need to filter (lines above)
        List<Transform> truePatrolPoints = new List<Transform>();


        foreach (Transform patrolPoint in patrolPoints)
        {
            if (patrolPoint.gameObject.transform.parent != null)//If parent is not null that means the the object is child
            {
                truePatrolPoints.Add(patrolPoint); //add the transform to the array of true patrol point
            }
        }



        pathToFollow = truePatrolPoints;
        //Debug.Log(patrolPoints[1].position);

        //for (int i = 0; i == pathToFollow.Length - 1; i++)
        //{
        //    string name;
        //    name = "Point " + i.ToString() + " (A)";
        //    Debug.Log(name);
        //   pathToFollow [i] = path.gameObject.transform.Find(name);



        //}

    }

}

