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
		print("Adding " + playerStorage.items.Count + " items to car storage ");
		carStorage.items.AddRange(playerStorage.items);
		playerStorage.items.Clear();
		print("Car storage count = " + carStorage.items.Count);
    }
}
