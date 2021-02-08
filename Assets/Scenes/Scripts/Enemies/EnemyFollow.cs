using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float range;
    public Transform target;//Follow
    
    public Transform[] moveSpots;//Patrol
    private Transform nextWayPoint;
    private Transform currentWayPoint;
    private bool nextWayPointReached;
    private Transform closestSpot;//Go back to Patrol
    int n;

    // Update is called once per frame

    private void Start()
    {
        nextWayPoint = moveSpots[0];
        nextWayPointReached = false;
    }


    void Update()
    {
        //Patrol

        //check nextwaypointreached

        if (Vector2.Distance(transform.position, nextWayPoint.position) < .2f)
                {
            nextWayPointReached = true;
            

        }

        //calcul nextwaypoint
     if (nextWayPointReached)
        {
        for (n = 0; n == moveSpots.Length -1 ; n++)
            {

                if (Vector2.Distance(transform.position, moveSpots[n].position) < Vector2.Distance(transform.position, moveSpots[n + 1].position)
                        && Vector2.Distance(transform.position, moveSpots[n].position) > 0.3f)
            {
                nextWayPoint = moveSpots[n];
                n++;
            }
                nextWayPointReached = false;
        }
        
      }

        if (!nextWayPointReached)
        {
            transform.position = Vector2.MoveTowards(transform.position, nextWayPoint.position, speed * Time.deltaTime);

        }


        //tant que nextwaypointreached est false -> move
        //des que nextwaypointreached est vrai -> calcul nextwaypoint et set nextwaypointreached = false


       /* 
        //Follow
        if (Vector2.Distance(transform.position, target.position) < range) 
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
        }
        //Go back to Patrol Behaviour
        else 
        {
            for (n=1; n==moveSpots.Length;n++)
            {
                closestSpot = moveSpots[0];

                if (Vector2.Distance(transform.position, moveSpots[n].position) < Vector2.Distance(transform.position, closestSpot.position))
                {
                    closestSpot = moveSpots[n];
                    n++;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, closestSpot.position,speed * Time.deltaTime);
            


        }*/



    }
}
