using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewItemMark : MonoBehaviour
{
    public float fadeAmount;

    Image i { get { return GetComponent<Image>(); } }

    public static NewItemMark Instance { get { return FindObjectOfType<NewItemMark>(); } }

    private IEnumerator _thread;

    public bool IsShown
    {
        set
        {
            i.enabled = value;
        }
    }

    private bool _isUrgent;
    public bool IsUrgent
    {
        get { return _isUrgent; }
        set
        {
            if (!value && IsUrgent)
            {
                StopCoroutine(_thread);
            }
            else if (value && !IsUrgent)
            {
                _thread = Blink();
                StartCoroutine(_thread);
            }
            _isUrgent = value;
        }
    }

    void Start()
    {
        IsUrgent = false;
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
