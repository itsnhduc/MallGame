using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCount : Singleton<ItemCount>
{
    Text t { get { return GetComponent<Text>(); } }

    public int Count
    {
        get { return int.Parse(t.text); }
        set { t.text = value.ToString(); }
    }
}
