using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class petrolBar : MonoBehaviour
{
    public Slider slider;
    public Text text;


    public void SetMaxPetrol(int maxPetrol)
    {
        slider.maxValue = maxPetrol;
        slider.value = maxPetrol;

        text.text = maxPetrol.ToString();
    }

    public void SetPetrol(int petrol)
    {
        slider.value = petrol;

        text.text = petrol.ToString();
    }
}
