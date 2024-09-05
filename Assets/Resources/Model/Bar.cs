using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [SerializeField] protected Slider slider; 

    public void SetMaxValue(int maxValue)
    {
        slider.maxValue = maxValue;
    }

    public void SetValue(float value)
    {
        slider.value = value;
    }

}
