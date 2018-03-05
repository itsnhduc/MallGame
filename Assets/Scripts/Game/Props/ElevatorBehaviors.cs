using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorBehaviors : Interactable
{
    public int floor;

    ElevatorPanelBehaviors elevatorPanel { get { return FindObjectOfType<ElevatorPanelBehaviors>(); } }

    public override void Activate()
    {
        GuyMovement.Instance.IsInControl = false;
        elevatorPanel.IsActive = true;
        elevatorPanel.ActiveFloor = floor;
    }
}
