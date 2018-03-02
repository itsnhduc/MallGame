using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public enum Type { Manual, AutoOnce }

    GameObject player { get { return GameObject.FindGameObjectWithTag("Player"); } }
    DialogService dialog { get { return FindObjectOfType<DialogService>(); } }

    [Header("Interactable")]
    public Type type;

    private bool _activated = false;
    public bool Activated
    {
        get { return _activated; }
        set
        {
            if (value) Activate(player);
            _activated = value;
        }
    }

    private bool _isInRange;
    public bool IsInRange
    {
        get { return _isInRange; }
        set
        {
            _isInRange = value;
            if (_isInRange) Hover(player);
            else Exit(player);
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

    public virtual void Hover(GameObject player) { }
    public virtual void Exit(GameObject player) { }
    public abstract void Activate(GameObject player);
}
