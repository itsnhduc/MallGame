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
    BoxCollider2D coll { get { return GetComponent<BoxCollider2D>(); } }

    public bool Spawned
    {
        get { return sp.enabled; }
        set { sp.enabled = value; coll.enabled = value; }
    }

    void Start()
    {
        // Spawned = false;
        Spawned = true;
    }

    public override void Activate()
    {
		Spawned = false;
		ItemStorage playerStorage = Guy.Instance.GetComponent<ItemStorage>();
		playerStorage.items.Add(this);
		DialogService.Instance.Show("Picked up " + productName, DialogService.ShortDuration);
        ItemList.Instance.Refresh();
    }

    public override void Hover()
    {
        DialogService.Instance.Show(productName + Environment.NewLine + "[E] Pick up");
    }
    public override void Exit()
    {
        DialogService.Instance.Clear();
    }
}
