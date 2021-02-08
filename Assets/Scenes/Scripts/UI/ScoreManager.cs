using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    
    public TextMeshProUGUI text;
    public int startingScore;
    public int coinCapacity;

    
    
  
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = "X"+startingScore.ToString() + "/" + coinCapacity.ToString();
    }


}
