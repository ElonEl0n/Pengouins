using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactAnimatorStates : MonoBehaviour
{
    Animator impactAnimator;
    public Impact impact;

    // Start is called before the first frame update
    void Start()
    {
        impact = GetComponentInParent<Impact>();
        impactAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    

        public void ImpactIsDone(string message)
        {
            if (message.Equals("ImpactDone")) // animation is over, time to destory the object
            {
            impact.Vanish();
            }
        }

}
