using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressureBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxPressure(float pressure)
    {
        slider.maxValue = pressure;
        slider.value = pressure;
    }

    public void SetPressure(float pressure)
    {
        slider.value = pressure;
    }
}
