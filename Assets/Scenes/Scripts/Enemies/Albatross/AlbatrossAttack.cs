using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlbatrossAttack : MonoBehaviour
{
    public float viewDistance;
    public Transform viewPoint;
    public Transform ejectionPoint;
    private Vector2 endAim;
   
    [SerializeField] private LayerMask layerMask;

    public float attackTime;//minimum time between two attacks
    public float attackTimeLocal;
    public bool launchTimer;
    public bool canAttack; //to wait right after snowball has been launched

    [SerializeField] public GameObject eggPrefab;
    public int eggNumber;
    public float dropRate;
    public int eggDropped;



    void Start()
    {
        attackTimeLocal = attackTime;
        canAttack = true;
        eggDropped = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer(viewDistance);
        if (CanSeePlayer(viewDistance) && canAttack)
        {

            EggAttack();
            //Debug.DrawLine(ejectionPoint.position, playerSpotted.position, Color.yellow);


        }

        //Cooldown logic
        if (launchTimer)
        {
            attackTimeLocal -= Time.deltaTime;
            if (attackTimeLocal < 0)
            {
                canAttack = true;
                launchTimer = false;
                attackTimeLocal = attackTime;
            }
        }
    }


    bool CanSeePlayer(float distance)
    {
        bool val = false;
        float castDistance = distance;

        Vector2 endAim = viewPoint.position + Vector3.down.normalized * castDistance;

        RaycastHit2D raycastHit2D = Physics2D.Linecast(viewPoint.position, endAim, layerMask);


        if (raycastHit2D.collider != null)
        {
            Debug.DrawLine(viewPoint.position, raycastHit2D.point, Color.blue);

            if (raycastHit2D.collider.gameObject.CompareTag("Player"))
            {
                val = true;

            }

        }
        else
        {
            Debug.DrawLine(viewPoint.position, endAim, Color.red);
            val = false;

        }

        return val;

    }

    private void EggAttack()
    {
        
        launchTimer = true;
        canAttack = false;

        StartCoroutine(DropEgg(eggPrefab, eggNumber, dropRate));
        
        //InvokeRepeating("DropEgg", eggNumber * dropRate + .05f, dropRate);//0.05f is added to make sure that the last egg is instanciated.
        

        //for (int i = 0; i < eggNumber; i++)
        //{
        //    float timer = 1/ dropRate;
        //    timer -= Time.deltaTime;

        //    if (timer<0)
        //    {
        //        DropEgg();
        //        i++;
        //    }
        //    //eggDrop = StartCoroutine(DropEgg(eggPrefab, dropRate));
        //}



    }

    //private void DropEgg()
    //{
    //    var egg = Instantiate(eggPrefab, ejectionPoint.position, Quaternion.identity) as GameObject;
    //}

    IEnumerator DropEgg(GameObject eggPrefab, int eggNumber, float dropRate) //coroutine
    {
        float time = 1 / dropRate;
        

        
        var egg = Instantiate(eggPrefab, ejectionPoint.position, Quaternion.identity) as GameObject;
        eggDropped++;
        yield return new WaitForSeconds(time);
        
        if (eggDropped < eggNumber)
        {
            StartCoroutine(DropEgg(eggPrefab, eggNumber, dropRate));
        }
        else
        {
            eggDropped = 0;
            yield break;
        }
    }
}
