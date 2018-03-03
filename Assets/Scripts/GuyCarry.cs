using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyCarry : MonoBehaviour
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

    public void Clear()
    {
        foreach (Transform bag in transform) Destroy(bag.gameObject);
		storage.items.Clear();
        _UpdateWeight();
    }

    private void _UpdateWeight()
    {
        GuyMovement.Instance.speedOffset = -1 * _GetTotalWeight() * weightMultiplier;
    }

    private float _GetTotalWeight()
    {
        return storage.items.Select(p => p.weight).Sum();
    }
}
