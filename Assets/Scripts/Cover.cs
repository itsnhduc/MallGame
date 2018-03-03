using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cover : MonoBehaviour
{
    Image i { get { return GetComponent<Image>(); } }

    public static Cover Instance { get { return FindObjectOfType<Cover>(); } }

    public bool IsOn
    {
        set
        {
			DialogService.Instance.DialogText = string.Empty;
            i.enabled = value;
        }
    }

    void Start()
    {
        IsOn = false;
    }
}
