using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalBehaviors : Singleton<GalBehaviors>
{
    public Sprite happySprite;
    public float happyDuration;
    public float shakeAngle;
    public float shakeInterval;
    public Sprite smileSprite;
    public float smileRange;

    SpriteRenderer sr { get { return GetComponent<SpriteRenderer>(); } }

    private Sprite _originalSprite;

    bool IsHappy
    {
        get { return sr.sprite == happySprite; }
        set
        {
            sr.sprite = value ? happySprite : _originalSprite;
            if (value) StartCoroutine(Shake());
        }
    }

    bool IsSmiling
    {
        get { return sr.sprite == smileSprite; }
        set
        {
            if (!IsHappy)
            {
                sr.sprite = value ? smileSprite : _originalSprite;
            }
        }
    }

    void Start()
    {
        _originalSprite = sr.sprite;
    }

    void Update()
    {
        Vector2 diff = GuyMovement.Instance.transform.position - transform.position;
        IsSmiling = Mathf.Abs(diff.y) < 1 && Mathf.Abs(diff.x) <= smileRange;
        transform.rotation = Quaternion.Euler(0, diff.x > 0 ? 180 : 0, 0);
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

    IEnumerator Shake()
    {
        int sign = 1;
        while (IsHappy)
        {
            transform.rotation = Quaternion.Euler(0, 0, sign * shakeAngle);
            sign *= -1;
            yield return new WaitForSeconds(shakeInterval);
        }
        transform.rotation = new Quaternion();
    }
}
