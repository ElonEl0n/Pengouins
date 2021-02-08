using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    // Start is called before the first frame update
    public void Vanish()
    {
        Destroy(gameObject);
    }
}
