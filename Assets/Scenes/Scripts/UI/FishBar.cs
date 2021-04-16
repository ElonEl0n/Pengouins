using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishBar : MonoBehaviour
{
    public Slider slider;
   
    public Image fill;

    //egg images
    public List<Sprite> images = new List<Sprite>();
    public GameObject currentEgg;
    public GameObject nextEgg;
    public int currentState;
    public int nextState;



    private void Start()
    {
        gameObject.SetActive(false);
        currentState = 0;
        nextState = 1;
        // currentEgg = GetComponentInChildren (Egg(n) and Egg(n+1)
        foreach (Transform child in gameObject.transform)
        {
            if (child.CompareTag("Egg(n)"))
                {
                currentEgg = child.gameObject;
            }

            if(child.CompareTag("Egg(n+1)"))
            {
                nextEgg = child.gameObject;
            }
        }
    }

   

    public void SetMaxFish(float maxFish)
    {
        slider.maxValue = maxFish;
        //slider.value = weapon.heatMax;
        //fill.color = gradient.Evaluate(1f);


    }

    public void SetFish(float fish)
    {
        slider.value = fish;


    }
    public void ChangeImages(int currentState, int nextState)

    {
        Image currentImage = currentEgg.GetComponent<Image>();
        Image nextImage = nextEgg.GetComponent<Image>();
        currentImage.sprite = images[currentState];
        nextImage.sprite = images[nextState];
    }

 


}
