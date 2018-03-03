using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : Interactable
{

    public override void Activate()
    {
        ItemStorage playerStorage = Guy.Instance.GetComponent<ItemStorage>();
        ItemStorage carStorage = GetComponent<ItemStorage>();
		if (playerStorage.items.Count > 0)
		{
			DialogService.Instance.Show(playerStorage.items.Count + " item(s) thrown into car trunk", DialogService.ShortDuration);
			carStorage.items.AddRange(playerStorage.items);
			playerStorage.items.Clear();
			ItemList.Instance.Refresh();
		}
    }

	public override void Hover()
	{
        ItemStorage playerStorage = Guy.Instance.GetComponent<ItemStorage>();
		if (playerStorage.items.Count > 0)
		{
			DialogService.Instance.Show("[E] Throw " + playerStorage.items.Count + " items into car trunk");
		}
	}
    public override void Exit()
    {
        DialogService.Instance.Clear();
    }
}
