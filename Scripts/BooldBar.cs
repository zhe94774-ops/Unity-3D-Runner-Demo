using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BooldBar : MonoBehaviour
{
    public Slider slider;
    public static BooldBar Instance;
    void Awake()
    {
        Instance = this;
    }
    public void SetMaxBoold(float f)
    {
        slider.maxValue = f;
        slider.value = f;
    }
    public void SetBoold(float f)
    {
        slider.value = f; 
    }

}
