using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorStates : MonoBehaviour
{
    Animator firePointAnimator;

    // Start is called before the first frame update
    void Start()
    {
        firePointAnimator = GetComponent<Animator>();
    }


    public void SmokeIsDone(string message)
    {
        if (message.Equals("SmokeDone"))
        {
            firePointAnimator.SetTrigger("Done");
        }
    }


}
