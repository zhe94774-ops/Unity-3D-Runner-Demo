using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Slider slider;
    public static Healthbar Instance;  //单例，在别的脚本中可以使用Healthbar.Instance精准找到这个脚本
    private void Awake()
    {
        Instance = this;
    }

    public void SetmaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }
    public void SetHealth(int health)
    {
        slider.value = health;
    }
}
