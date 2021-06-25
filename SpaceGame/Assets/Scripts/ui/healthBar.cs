using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class healthBar : MonoBehaviour
{

    public Slider slider;
    //public Text text;
    public TextMeshProUGUI text;


    public void SetMaxHealth(int maxHealth)
    {
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        text.text = maxHealth.ToString();
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        text.text = health.ToString();
    }
}

//https://www.youtube.com/watch?v=BLfNP4Sc_iA