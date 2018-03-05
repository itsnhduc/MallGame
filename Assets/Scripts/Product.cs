using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : Interactable
{
    [Header("Product")]
    public string productName;
    public int weight;
    public Sprite icon;

    public const float buyDuration = 1.5f;
    public const float moveY = 0.5f;
    public const float animateAmount = 0.05f;

    SpriteRenderer sp { get { return GetComponent<SpriteRenderer>(); } }
    BoxCollider2D coll { get { return GetComponent<BoxCollider2D>(); } }

    private Vector2 _originalPos;
    private Vector2 _animatedPos;
    private IEnumerator _thread;

    public bool Spawned
    {
        get { return sp.enabled; }
        set
        {
            sp.enabled = value;
            coll.enabled = value;
            if (value)
            {
                _thread = Animate();
                StartCoroutine(_thread);
            }
            else
            {
                StopCoroutine(_thread);
            }
        }
    }

    void Start()
    {
        _originalPos = transform.position;
        _animatedPos = _originalPos + new Vector2(0, moveY);
    }

    public override void Activate()
    {
        StartCoroutine(Buy());
    }

    public override void Hover()
    {
        DialogService.Instance.Show(productName + Environment.NewLine + "[E/Enter] Buy Item");
    }
    public override void Exit()
    {
        DialogService.Instance.Clear();
    }

    IEnumerator Buy()
    {
        Spawned = false;
        GuyMovement.Instance.IsEnabled = false;
        PhoneBehaviors.Instance.IsEnabled = false;
        yield return new WaitForSeconds(buyDuration);
        GuyMovement.Instance.IsEnabled = true;
        PhoneBehaviors.Instance.IsEnabled = true;
        GuyCarry.Instance.Add(this);
        DialogService.Instance.Show("Bought " + productName, DialogService.ShortDuration);
        // ItemList.Instance.Refresh();
        ItemList.Instance.Check(productName);
    }

    IEnumerator Animate()
    {
        int sign = -1;
        float multiplier = 0;
        while (true)
        {
            if (multiplier <= 0 && sign == -1 || multiplier >= 1 && sign == 1) sign *= -1;
            multiplier += sign * animateAmount;
            transform.position = Vector2.Lerp(_originalPos, _animatedPos, multiplier);
            yield return new WaitForFixedUpdate();
        }
    }
}
