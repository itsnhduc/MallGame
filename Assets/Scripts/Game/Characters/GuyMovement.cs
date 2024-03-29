﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMovement : Singleton<GuyMovement>
{
    public float speed;
    public int floorHeight;
    public float staminaBaseDecrease;
    public float staminaModifier;
    public float staminaRegen;
    public float staminaDrainDuration;
    public float haltDuration;
    public Sprite tiredSprite;
    public Sprite haltSprite;
    public Sprite smileSprite;
    public float smileRange;

    public float SpeedOffset { get; set; }
    public bool IsInControl { get; set; }

    Rigidbody2D rb { get { return GetComponent<Rigidbody2D>(); } }
    SpriteRenderer sr { get { return GetComponent<SpriteRenderer>(); } }
    public float TrueSpeed { get { return Mathf.Max(speed + SpeedOffset, 0); } }

    private Sprite _originalSprite;

    public Vector2 MoveDirection
    {
        get { return rb.velocity.normalized; }
        set
        {
            rb.velocity = value * TrueSpeed;
            if (value != Vector2.zero)
            {
                int rotY = value == Vector2.right ? 180 : 0;
                transform.rotation = Quaternion.Euler(0, rotY, 0);
            }
        }
    }

    private int _floor;
    public int Floor
    {
        get { return _floor; }
        set
        {
            Vector3 offset = new Vector3(0, (value - Floor) * floorHeight, 0);
            Vector3 padding = transform.eulerAngles.y == 0 ? Vector2.right : Vector2.left;
            transform.position += offset + padding;
            transform.Rotate(0, 180, 0);
            Camera.main.transform.position += offset;
            _floor = value;
        }
    }

    public bool IsHalted
    {
        get { return sr.sprite == haltSprite; }
        set
        {
            IsInControl = !value;
            PhoneBehaviors.Instance.IsEnabled = !value;
            sr.sprite = value ? haltSprite : _originalSprite;
            BackgroundMusic.Instance.IsScratched = IsHalted;
        }
    }

    public bool IsEnabled
    {
        set
        {
            sr.enabled = value;
            IsInControl = value;
        }
    }

    public bool IsTired
    {
        get { return sr.sprite == tiredSprite; }
        set
        {
            if (!IsHalted && !IsSmiling) sr.sprite = value ? tiredSprite : _originalSprite;
            BackgroundMusic.Instance.Pitch = value ? TrueSpeed / speed : 1;
        }
    }

    bool IsSmiling
    {
        get { return sr.sprite == smileSprite; }
        set
        {
            sr.sprite = value ? smileSprite : _originalSprite;
        }
    }

    void Start()
    {
        _originalSprite = sr.sprite;
        IsInControl = true;
        SpeedOffset = 0;
        StartCoroutine(DrainStamina());
    }

    void Update()
    {
        if (StaminaSlider.Instance.Percentage <= 0.001f)
        {
            StartCoroutine(Halt());
        }

        if (IsInControl)
        {
            bool leftKey = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
            bool rightKey = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
            MoveDirection = leftKey ? Vector2.left : (rightKey ? Vector2.right : Vector2.zero);
        }
        else
        {
            MoveDirection = Vector2.zero;
        }

        if (!IsTired && !IsHalted)
        {
            Vector2 diff = transform.position - GalBehaviors.Instance.transform.position; 
            IsSmiling = Mathf.Abs(diff.y) < 1 && Mathf.Abs(diff.x) <= smileRange;
        }
    }

    IEnumerator DrainStamina()
    {
        while (true)
        {
            if (Time.timeScale!=0)
            {
                if (rb.velocity != Vector2.zero)
                {
                    float offset = staminaBaseDecrease + staminaModifier * Mathf.Abs(SpeedOffset);
                    StaminaSlider.Instance.Percentage -= offset;
                }
                else
                {
                    StaminaSlider.Instance.Percentage += staminaRegen;
                }
            }
            yield return new WaitForSeconds(staminaDrainDuration);
           
        }
    }

    IEnumerator Halt()
    {
        IsHalted = true;
        yield return new WaitForSeconds(haltDuration);
        IsHalted = false;
    }
}
