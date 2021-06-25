using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class petrolBar : MonoBehaviour
{
    public Slider slider;
    public TextMeshProUGUI text;


    public void SetMaxEnergy(float maxEnergy)
    {
        slider.maxValue = maxEnergy;
        slider.value = maxEnergy;

        text.text = maxEnergy.ToString();
    }

    public void SetEnergy(float energy)
    {
        slider.value = energy;

        text.text = energy.ToString();
    }
}
