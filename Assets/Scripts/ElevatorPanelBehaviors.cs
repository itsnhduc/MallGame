using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorPanelBehaviors : MonoBehaviour
{
    SpriteRenderer sp { get { return GetComponent<SpriteRenderer>(); } }
    GuyMovements guy { get { return FindObjectOfType<GuyMovements>(); } }

    public bool IsActive
    {
        get { return sp.enabled; }
        set { sp.enabled = value; }
    }

    private int _activeFloor;
    public int ActiveFloor
    {
        get { return _activeFloor; }
        set
        {
            if (_activeFloor != -1) transform.GetChild(_activeFloor).gameObject.SetActive(false);
            if (value != -1) transform.GetChild(value).gameObject.SetActive(true);
            DialogService.Instance().Show("Going to " + (value > 0 ? "Floor " + value : "the Basement"));
            _activeFloor = value;
        }
    }

    void Update()
    {
        if (IsActive)
        {
            // escape
            bool esc = Input.GetKeyDown(KeyCode.Escape);
            if (esc)
            {
                IsActive = false;
                ActiveFloor = -1;
                guy.isInControl = true;
            }

            // select floor
            bool leftKey = Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A);
            bool rightKey = Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D);
            int offset = leftKey ? -1 : (rightKey ? 1 : 0);
            ActiveFloor = (ActiveFloor + offset + transform.childCount) % transform.childCount;

            // move to floor
            bool useKey = Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return);
            if (useKey)
            {
                guy.Floor = ActiveFloor;
                ActiveFloor = -1;
                guy.isInControl = true;
                IsActive = false;
                DialogService.Instance().Clear();
            }
        }
    }
}
