using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyMovement : MonoBehaviour
{
    public float speed;
    public int floorHeight;

    public float speedOffset { get; set; }
    public static GuyMovement Instance { get { return FindObjectOfType<GuyMovement>(); } }

    Rigidbody2D rb { get { return GetComponent<Rigidbody2D>(); } }

    public bool isInControl { get; set; }

    public Vector2 MoveDirection
    {
        set
        {
            rb.velocity = value * (speed + speedOffset);
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

    void Start()
    {
        isInControl = true;
        speedOffset = 0;
    }

    void Update()
    {
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
}
