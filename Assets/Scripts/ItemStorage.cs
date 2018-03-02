using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    public List<Product> items { get; private set; }

	void Start()
	{
		items = new List<Product>();
	}
}
