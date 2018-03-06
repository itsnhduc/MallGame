using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : Singleton<StaminaSlider>
{
    public float tiredThreshold;
    
    Slider s { get { return GetComponent<Slider>(); } }

    public float Percentage
    {
        get { return s.value; }
        set
        {
            s.value = value;
            GuyMovement.Instance.IsTired = value <= tiredThreshold;
            StaminaOverlay.Instance.Visibility = (tiredThreshold - value) / tiredThreshold;
        }
    }
}
