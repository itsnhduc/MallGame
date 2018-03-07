using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doge : MonoBehaviour
{
	public float dogeSpeed;

	public void Activate()
	{
		GetComponent<Rigidbody2D>().velocity = Vector2.right * dogeSpeed;
	}

	public void Deactivate()
	{
		Destroy(gameObject);
	}
}
