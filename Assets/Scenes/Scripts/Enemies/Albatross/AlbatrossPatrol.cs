using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbatrossPatrol : MonoBehaviour
{

    public GameObject pathToLoad;
    public List<Transform> pathToFollow = new List<Transform>();
    //public GameObject patrolPoints;
    //public int pathLength;
    public int currentPoint;
    public Transform nextWayPoint;
    public float roundingDistance;
    private Rigidbody2D rb2d;


    public float moveSpeed;
    Vector2 lastPos;
    Vector2 newPos;
    Vector2 trackVelocity;
    public bool facingRight;

    public EnemyDeath enemyDeath;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        lastPos = transform.position;
        newPos = transform.position;
        facingRight = true;
        enemyDeath = GetComponent<EnemyDeath>();
        InstantiatePatrolPoints();
        


        //patrolPoints = GameObject.FindGameObjectWithTag("PatrolPoint");

        //Path initialization




    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Patrol();
        Orientation();
    }


    private void Patrol()
    {

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

    }

    private void Orientation()
    {
        newPos = transform.position;
        trackVelocity = (newPos - lastPos) / Time.fixedDeltaTime;
        lastPos = newPos;

        if (trackVelocity.x > 0 && (!facingRight))
        {
            facingRight = true;
            transform.Rotate(0f, 180f, 0f);
        }

        else if (trackVelocity.x < 0 && (facingRight))
        {
            facingRight = false;
            transform.Rotate(0f, 180f, 0f);
        }




    }

    private void InstantiatePatrolPoints()
    {
        
        var path = Instantiate(pathToLoad, transform.position, Quaternion.identity) as GameObject;
        enemyDeath.patrolPoints = path;
        Transform[] patrolPoints = path.GetComponentsInChildren<Transform>();//Gets also the parent object so need to filter (lines above)
        List<Transform> truePatrolPoints = new List<Transform>();
        
       
        foreach ( Transform patrolPoint in patrolPoints)
        {
            if(patrolPoint.gameObject.transform.parent != null)//If parent is not null that means the the object is child
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
