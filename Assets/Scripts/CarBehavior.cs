using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : Interactable
{

    public override void Activate()
    {
        var carStorage = GetComponent<ItemStorage>();
        var guyCarry = FindObjectOfType<GuyCarry>();
		if (guyCarry.Items.Count > 0)
		{
			DialogService.Instance.Show(guyCarry.Items.Count + " item(s) dropped", DialogService.ShortDuration);
			carStorage.items.AddRange(guyCarry.Items);
			guyCarry.Clear();
			ItemList.Instance.Refresh();
		}
    }

	public override void Hover()
	{
        var guyCarry = FindObjectOfType<GuyCarry>();
		if (guyCarry.Items.Count > 0)
		{
			DialogService.Instance.Show("[E] Drop " + guyCarry.Items.Count + " items");
		}
	}
    public override void Exit()
    {
        DialogService.Instance.Clear();
    }
}
