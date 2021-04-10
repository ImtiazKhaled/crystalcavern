using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpecialBar : MonoBehaviour
{
    public Slider slider;
    
    public void SetMaxSpecial(int special)
    {
        slider.maxValue = special;
        slider.value = 0;
    }
    public void SetSpecial(int special)
    {
        slider.value = special;
    }
}
