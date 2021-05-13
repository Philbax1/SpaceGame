using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class petrolBar : MonoBehaviour
{
    public Slider slider;
    public Text text;


    public void SetMaxEnergy(int maxEnergy)
    {
        slider.maxValue = maxEnergy;
        slider.value = maxEnergy;

        text.text = maxEnergy.ToString();
    }

    public void SetEnergy(int energy)
    {
        slider.value = energy;

        text.text = energy.ToString();
    }
}
