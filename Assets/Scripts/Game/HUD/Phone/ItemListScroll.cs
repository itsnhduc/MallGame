using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemListScroll : MonoBehaviour
{
    public int minScrollNumber;
    public float speed;

    Rigidbody2D rb { get { return GetComponent<Rigidbody2D>(); } }

    public Vector2 MoveDirection { set { rb.velocity = value * speed; } }

    private Vector2 _originalLocalPos;

    void Start()
    {
        _originalLocalPos = transform.localPosition;
    }

    void Update()
    {
        if (transform.childCount >= minScrollNumber)
        {
            bool upKey = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
            bool downKey = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
            if (upKey || downKey) MoveDirection = upKey ? Vector2.up : Vector2.down;
            else MoveDirection = Vector2.zero;
            if (transform.localPosition.y < _originalLocalPos.y)
            {
                MoveDirection = Vector2.zero;
                transform.localPosition = _originalLocalPos;
            }
        }
    }
}
