using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneBehaviors : Singleton<PhoneBehaviors>
{
    public float showOffsetY;
    public float speedMultiplier;

    private IEnumerator _thread;

    public bool IsEnabled { get; set; }

    private bool _isShown;
    public bool IsShown
    {
        get { return _isShown; }
        set
        {
            if (IsShown != value)
            {
                NewItemMark.Instance.IsShown = false;
                Cover.Instance.IsOn = value;
                GuyMovement.Instance.IsInControl = !value;
                if (_thread != null && IsShown != value) StopCoroutine(_thread);
                _thread = Move(value);
                StartCoroutine(_thread);
            }
        }
    }

    void Start()
    {
        IsEnabled = true;
        IsShown = false;
    }

    void Update()
    {
        bool showKey = Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift);
        if (showKey && IsEnabled) IsShown = !IsShown;
    }

    IEnumerator Move(bool isShowing)
    {
        Rigidbody2D camRb = Camera.main.GetComponent<Rigidbody2D>();
        while (camRb.velocity != Vector2.zero)
        {
            yield return new WaitForEndOfFrame();
        }
        _isShown = isShowing;
        Vector2 targetPos = (Vector2)transform.position + new Vector2(0, showOffsetY * (isShowing ? 1 : -1));
        float timeDelta = 0.01f;
        float timePassed = 0;
        while (timePassed < 1)
        {
            timePassed += timeDelta * speedMultiplier;
            transform.position = Vector2.Lerp(transform.position, targetPos, timePassed);
            yield return new WaitForSeconds(timeDelta);
        }
    }
}
