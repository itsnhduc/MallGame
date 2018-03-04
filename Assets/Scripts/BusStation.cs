using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStation : MonoBehaviour
{
	public GameObject busPrefab;
	public float spawnDurationMin;
	public float spawnDurationMax;

	void Start()
	{
		StartCoroutine(SpawnBuses());
	}

	IEnumerator SpawnBuses()
	{
		while (true)
		{
			Instantiate(busPrefab, transform);
			float duration = UnityEngine.Random.Range(spawnDurationMin, spawnDurationMax);
			yield return new WaitForSeconds(duration);
		}
	}
}
