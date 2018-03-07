using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour
{
	public GameObject progressCircle;

	public void SetProgressCircle(bool isShown)
	{
		progressCircle.SetActive(isShown);
	}
}
