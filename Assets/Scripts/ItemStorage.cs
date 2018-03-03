using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStorage : MonoBehaviour
{
    private List<Product> _items = new List<Product>();
    public List<Product> items { get { return _items; } }
}
