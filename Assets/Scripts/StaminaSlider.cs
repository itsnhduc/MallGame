using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : Singleton<StaminaSlider>
{
    Slider s { get { return GetComponent<Slider>(); } }

    public float Percentage
    {
        get { return s.value; }
        set { s.value = value; }
    }
}
