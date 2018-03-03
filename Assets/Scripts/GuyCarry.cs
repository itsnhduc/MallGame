using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyCarry : MonoBehaviour
{
    public GameObject shoppingBagPrefab;

    ItemStorage storage { get { return Guy.Instance.GetComponent<ItemStorage>(); } }

    public List<Product> Items
    {
        get { return storage.items; }
    }

    public void Add(Product product)
    {
        GameObject bag = Instantiate(shoppingBagPrefab, transform);
		bag.GetComponent<ShoppingBag>().Scale = product.weight;
		storage.items.Add(product);
    }

    public void Clear()
    {
        foreach (Transform bag in transform) Destroy(bag.gameObject);
		storage.items.Clear();
    }
}
