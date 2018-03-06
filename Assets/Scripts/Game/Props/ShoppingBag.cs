using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingBag : MonoBehaviour
{
	public const float scaleMultiplier = 1f;
    public readonly Vector2 rnRange = new Vector2(0.5f, 0.1f);

	void Awake()
	{
        float offsetX = UnityEngine.Random.Range(-rnRange.x, rnRange.x);
        float offsetY = UnityEngine.Random.Range(-rnRange.y, rnRange.y);
        transform.position += new Vector3(offsetX, offsetY, 0);
	}

	public float Scale
	{
		set { transform.localScale = Vector3.one * value * scaleMultiplier; }
	}
}
