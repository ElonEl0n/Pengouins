using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCooldownBar : MonoBehaviour
{

    public Slider slider;
    //public Gradient gradient;
    public Image fill;
    //public Weapon weapon;
    

    // Start is called before the first frame update

    public void SetMaxHeat(float heat)
    {
        slider.maxValue = heat;
        //slider.value = weapon.heatMax;
        //fill.color = gradient.Evaluate(1f);
        

    }

    public void SetHeat(float heat)
    {
        slider.value = heat;
        

    }

   
}
