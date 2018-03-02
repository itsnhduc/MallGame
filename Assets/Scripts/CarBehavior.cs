using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehavior : Interactable
{

    public override void Activate(GameObject player)
    {
        ItemStorage playerStorage = player.GetComponent<ItemStorage>();
        ItemStorage carStorage = GetComponent<ItemStorage>();
		if (playerStorage.items.Count > 0)
		{
			DialogService.Instance().Show(playerStorage.items.Count + " items thrown into car trunk", DialogService.ShortDuration);
			carStorage.items.AddRange(playerStorage.items);
			playerStorage.items.Clear();
		}
    }

	public override void Hover(GameObject player)
	{
        ItemStorage playerStorage = player.GetComponent<ItemStorage>();
		if (playerStorage.items.Count > 0)
		{
			DialogService.Instance().Show("Press E to throw " + playerStorage.items.Count + " items into car trunk");
		}
	}
    public override void Exit(GameObject player)
    {
        DialogService.Instance().Clear();
    }
}
