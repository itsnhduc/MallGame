using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehaviors : Interactable
{
    public int floor;
    public ElevatorPanelBehaviors elevatorPanel;

    private bool _isBeingUsed = false;
    public bool IsBeingUsed
    {
        get { return _isBeingUsed; }
        set { _isBeingUsed = value; }
    }

    public override void Activate()
    {
        if (!IsBeingUsed)
        {
            GuyMovement.Instance.IsInControl = false;
            elevatorPanel.gameObject.SetActive(true);
            elevatorPanel.ActiveFloor = floor;
            IsBeingUsed = true;
        }
    }

    public override void Hover()
    {
        DialogService.Instance.Show("[E/Enter] Use elevator");
    }
}
