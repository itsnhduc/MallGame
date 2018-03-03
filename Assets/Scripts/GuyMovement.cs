using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMovement : MonoBehaviour
{
    public float speed;
    public int floorHeight;
    public float staminaBaseDecrease;
    public float staminaModifier;
    public float staminaRegen;
    public float staminaDrainDuration;
    public float haltDuration;
    public Sprite haltSprite;

    public float speedOffset { get; set; }
    public bool isInControl { get; set; }

    public static GuyMovement Instance { get { return FindObjectOfType<GuyMovement>(); } }

    Rigidbody2D rb { get { return GetComponent<Rigidbody2D>(); } }
    SpriteRenderer sr { get { return GetComponent<SpriteRenderer>(); } }
    public float TrueSpeed { get { return speed + speedOffset; } }

    private Sprite _originalSprite;

    public Vector2 MoveDirection
    {
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
        set
        {
            isInControl = !value;
            sr.sprite = value ? haltSprite : _originalSprite;
        }
    }

    void Start()
    {
        _originalSprite = sr.sprite;
        isInControl = true;
        speedOffset = 0;
        StartCoroutine(DrainStamina());
    }

    void Update()
    {
        if (StaminaSlider.Instance.Percentage <= 0.001f)
        {
            StartCoroutine(Halt());
        }

        if (isInControl)
        {
            bool leftKey = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
            bool rightKey = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);
            MoveDirection = leftKey ? Vector2.left : (rightKey ? Vector2.right : Vector2.zero);
        }
        else
        {
            MoveDirection = Vector2.zero;
        }
    }

    IEnumerator DrainStamina()
    {
        while (true)
        {
            if (rb.velocity != Vector2.zero)
            {
                float offset = staminaBaseDecrease + staminaModifier * Mathf.Abs(speedOffset);
                StaminaSlider.Instance.Percentage -= offset;
            }
            else
            {
                StaminaSlider.Instance.Percentage += staminaRegen;
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
