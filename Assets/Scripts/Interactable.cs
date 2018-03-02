using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum Type { Manual, AutoOnce }

    public GameObject player { get { return GameObject.FindGameObjectWithTag("Player"); } }

    [Header("Interactable")]
    public Type type;

    private bool _activated = false;
    public bool Activated
    {
        get { return _activated; }
        set
        {
            if (value) Activate(player);
            else Deactivate(player);
            _activated = value;
        }
    }

    private bool _isInRange;
    public bool IsInRange
    {
        get { return _isInRange; }
        set
        {
            // show item name
            _isInRange = value;
        }
    }

    void Update()
    {
        switch (type)
        {
            case Type.AutoOnce:
                if (IsInRange && !Activated || !IsInRange && Activated) Activated = !Activated;
                break;
            case Type.Manual:
                bool useKey = Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return);
                if (useKey && IsInRange) Activate(player);
                break;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        IsInRange = other.tag == "Player";
    }

    void OnTriggerExit2D(Collider2D other)
    {
        IsInRange = false;
    }

    public abstract void Activate(GameObject player);
    public virtual void Deactivate(GameObject player) { }
}
