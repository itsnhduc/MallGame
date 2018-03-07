using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DangerOverlay : MonoBehaviour
{
    public float fadeAmount;

    Image i { get { return GetComponent<Image>(); } }

    public bool IsShown
    {
        set { i.enabled = value; }
    }

    void OnEnable()
    {
        StartCoroutine(Blink());
    }

    IEnumerator Blink()
    {
        int sign = -1;
        while (true)
        {
            if (i.color.a <= 0 && sign == -1 || i.color.a >= 1 && sign == 1) sign *= -1;
            i.color += new Color(0, 0, 0, sign * fadeAmount);
            yield return new WaitForFixedUpdate();
        }
    }
}
