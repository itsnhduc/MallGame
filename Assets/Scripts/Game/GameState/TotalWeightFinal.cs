using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalWeightFinal : MonoBehaviour
{
	public string tail;

    Text t { get { return GetComponent<Text>(); } }

    void Start()
    {
		t.text = TotalWeightDisplay.Instance.Value + tail;
    }
}
