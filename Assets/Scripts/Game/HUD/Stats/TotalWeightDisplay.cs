using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalWeightDisplay : Singleton<TotalWeightDisplay>
{
    Text t { get { return GetComponent<Text>(); } }

    public int Value
    {
        get { return int.Parse(t.text); }
        set { t.text = value.ToString(); }
    }

	void Start()
	{
		Value = 0;
	}
}
