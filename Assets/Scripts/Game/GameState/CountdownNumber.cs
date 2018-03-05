using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownNumber : MonoBehaviour
{
    Text t { get { return GetComponent<Text>(); } }

    public string Text
    {
        set { t.text = value; }
    }
}
