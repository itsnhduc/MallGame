using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusStationBackground : MonoBehaviour
{
    public float parallaxSpeed;
    public float minRangeX;

    Rigidbody2D rb { get { return GetComponent<Rigidbody2D>(); } }

    void Update()
    {
		if (Mathf.Abs(Camera.main.transform.position.x - transform.position.x) <= minRangeX)
		{
        	rb.velocity = -Camera.main.GetComponent<Rigidbody2D>().velocity.normalized * parallaxSpeed;
		}
    }
}
