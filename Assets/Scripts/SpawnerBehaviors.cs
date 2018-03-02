using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviors : MonoBehaviour
{
    private List<Product> _products;

    void Start()
    {
        _products = FindObjectsOfType<Product>().ToList().OrderBy(p => p.weight).ToList();
		StartCoroutine(StartSpawning());
    }

	IEnumerator StartSpawning()
	{
		// do stuff
		yield return null;
	}
}