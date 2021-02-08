using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn; //thing to spawn
                             //stores the game object, so that is still available after Destroy();
                             //info that thing to spawn has disappeared
    public float time;//time to wait before spawning a new thing


    //public void Reset(Vector2 childPos, GameObject toDestroy)
    public void Reset( GameObject toDestroy)
    {

        toDestroy.SetActive(false);
        StartCoroutine(Spawn(toDestroy, time));

    }

    IEnumerator Spawn(GameObject toSpawn, float time)
    {
        yield return new WaitForSeconds(time);

        toSpawn.SetActive(true);

    }
}

    
    

       /* StartCoroutine(Spawn(spawn, childPos, time));
    }

    IEnumerator Spawn(GameObject toSpawn, Vector2 childPos, float time)
    {
        yield return new WaitForSeconds(time);

       

        GameObject mySpawn = Instantiate(toSpawn, childPos, Quaternion.identity) as GameObject; //try with a random pos, then set transform as parent, then set child pos.
        mySpawn.transform.SetParent(transform);
    }*/
    //destroy the child
    //wait
    //instantiate a new thing as a child and at the position of the child (store the child transform.position in a variable)
    //set new thing's parent the spawner object with s1Button.transform.SetParent(ChoiceButtonHolder.transform);

//}
