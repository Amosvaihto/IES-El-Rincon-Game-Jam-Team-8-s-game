using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GameUtils
{

    public static float basePositionX = -1f;

    public static void UpdateSliderBar(Slider slider, float currentValue, float maxValue){
        slider.value = currentValue / maxValue;
    }
}

