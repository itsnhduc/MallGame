using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Product : Interactable
{
    [Header("Product")]
    public string productName;
    public float weight;

    SpriteRenderer sp { get { return GetComponent<SpriteRenderer>(); } }

    public bool Spawned
    {
        get { return sp.enabled; }
        set { sp.enabled = value; }
    }

    void Start()
    {
        // Spawned = false;
        Spawned = true;
    }

    public override void Activate(GameObject player)
    {
		if (Spawned)
		{
			Spawned = false;
			ItemStorage playerStorage = player.GetComponent<ItemStorage>();
			playerStorage.items.Add(this);
			print("Added item " + productName);
		}
    }
}
