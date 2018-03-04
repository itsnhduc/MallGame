using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalBehaviors : Singleton<GalBehaviors>
{
    public Sprite happySprite;
	public float happyDuration;

    SpriteRenderer sr { get { return GetComponent<SpriteRenderer>(); } }

	private Sprite _originalSprite;

    bool IsHappy
	{
		set
		{
			sr.sprite = value ? happySprite : _originalSprite;
		}
	}

	void Start()
	{
		_originalSprite = sr.sprite;
	}

	public void BecomeHappy()
	{
		StartCoroutine(Happy());
	}

	IEnumerator Happy()
	{
		IsHappy = true;
		yield return new WaitForSeconds(happyDuration);
		IsHappy = false;
	}
}
