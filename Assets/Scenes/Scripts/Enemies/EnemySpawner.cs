using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float time;
    public Transform enemySpawner;
    

    private void Start()
    {
        enemySpawner = GetComponent<Transform>();
    }

    public void Reset()
    {

       
        StartCoroutine(Spawn(enemy, time));

    }

    IEnumerator Spawn(GameObject toSpawn, float time)
    {
        yield return new WaitForSeconds(time);

        var enemy = Instantiate(toSpawn, enemySpawner.position, Quaternion.identity) as GameObject;
        var enemyDeath = enemy.GetComponent<EnemyDeath>();
        enemyDeath.enemySpawner = this;



    }

}
