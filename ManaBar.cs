using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    public Slider slider;
    public Gradient grad;
    public Image fill;


    public void SetMaxMana(int mana)
    {
        slider.maxValue = mana;
        slider.value = mana;

        fill.color = grad.Evaluate(1f);
    }

    public void setMana(int mana)
    {
        slider.value = mana;

        fill.color = grad.Evaluate(slider.normalizedValue);
    }
}
