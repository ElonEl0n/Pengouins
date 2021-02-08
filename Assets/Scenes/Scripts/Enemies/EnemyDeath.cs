using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public GameObject patrolPoints;
    public EnemyHealth enemyHealth;
    public GameObject deathEffect;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
       

    }

    public void Die()
    {
        
        enemySpawner.Reset();
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }
        Destroy(patrolPoints);
        Destroy(gameObject);

        
    }

    // Start is called before the first frame update
    //if Die() is called
    //call enemySpawner.reset(gameobject)
}
