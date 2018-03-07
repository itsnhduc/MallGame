using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyCarry : Singleton<GuyCarry>
{
    public GameObject shoppingBagPrefab;
    public float weightMultiplier;

    ItemStorage storage { get { return GuyMovement.Instance.GetComponent<ItemStorage>(); } }

    public List<Product> Items
    {
        get { return storage.items; }
    }

    public void Add(Product product)
    {
        GameObject bag = Instantiate(shoppingBagPrefab, transform);
		bag.GetComponent<ShoppingBag>().Scale = product.weight;
		storage.items.Add(product);
        _UpdateWeight();
    }

    public bool Has(Product product)
    {
        return storage.items.Find(p => p.productName == product.productName) != null;
    }

    public void Clear()
    {
        while (transform.childCount != 0)
        {
            transform.GetChild(0).parent = null;
        }
		storage.items.Clear();
        _UpdateWeight();
    }

    private void _UpdateWeight()
    {
        GuyMovement.Instance.SpeedOffset = -1 * _GetTotalWeight() * weightMultiplier;
    }

    private float _GetTotalWeight()
    {
        return storage.items.Select(p => p.weight).Sum();
    }
}
