using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    //Variables
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    //Sets health value to healthbar value whenever called
    public void CurrentHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    //Sets maxhealth value to healthbar whenever called
    public void MaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;

        gradient.Evaluate(1f);
    }
}
