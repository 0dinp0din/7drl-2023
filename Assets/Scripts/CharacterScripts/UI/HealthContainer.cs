using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthContainer : MonoBehaviour
{

    public Slider slider;
    public GameObject textObject;
    private TextMeshProUGUI text;

    private void Start()
    {
        text = textObject.GetComponent<TextMeshProUGUI>();
    }


    public void setMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
        text.text = health + " hp";
    }
    
    public void setHealth(float health)
    {
        slider.value = health;
        text.text = health + " hp";
    }
}
