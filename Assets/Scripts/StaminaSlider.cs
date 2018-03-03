using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaSlider : MonoBehaviour
{
    Slider s { get { return GetComponent<Slider>(); } }

    public static StaminaSlider Instance { get { return FindObjectOfType<StaminaSlider>(); } }

    public float Percentage
    {
        get { return s.value; }
        set { s.value = value; }
    }
}
