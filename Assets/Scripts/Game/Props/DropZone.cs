using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : Interactable
{
	public AudioClip doneSound;

    public override void Activate()
    {
        var carStorage = GetComponent<ItemStorage>();
        var guyCarry = FindObjectOfType<GuyCarry>();
		if (guyCarry.Items.Count > 0)
		{
			DialogService.Instance.Show(guyCarry.Items.Count + " item(s) dropped", DialogService.ShortDuration);
			carStorage.items.AddRange(guyCarry.Items);
			guyCarry.Items.ForEach(p => ItemList.Instance.Remove(p.productName));
			guyCarry.Clear();
			GalBehaviors.Instance.BecomeHappy();
			SoundSource.Instance.Src.PlayOneShot(doneSound);
		}
		TotalWeightDisplay.Instance.Value = carStorage.items.Select(p => p.weight).Sum();
    }

	public override void Hover()
	{
        var guyCarry = FindObjectOfType<GuyCarry>();
		if (guyCarry.Items.Count > 0)
		{
			DialogService.Instance.Show("[E/Enter] Drop " + guyCarry.Items.Count + " items");
		}
	}
    public override void Exit()
    {
        DialogService.Instance.Clear();
    }
}
