using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaOverlay : Singleton<StaminaOverlay>
{
    public float maxAmount;
    public GameObject pauseOverlay;

    Image i { get { return GetComponent<Image>(); } }

    public float Visibility
    {
        set
        {
			if (!GuyMovement.Instance.IsHalted)
			{
				i.color = new Color(i.color.r, i.color.g, i.color.b, value * maxAmount);
				pauseOverlay.SetActive(value >= 1);
			}
        }
    }
}
