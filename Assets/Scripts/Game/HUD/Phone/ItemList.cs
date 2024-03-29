﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : Singleton<ItemList>
{
    public GameObject listItemPrefab;

    public List<ListItem> Products
    {
        get { return GetComponentsInChildren<ListItem>().ToList(); }
    }

    public void Add(string productName, Sprite productIcon)
    {
        GameObject newItemList = Instantiate(listItemPrefab, transform);
        newItemList.name = productName;
        ListItem li = newItemList.GetComponent<ListItem>();
        li.Index = Products.Count - 1;
        li.Text = productName;
        li.IsChecked = false;
        li.Icon = productIcon;
        ItemCount.Instance.Count += 1;
    }

    public void Check(string productName)
    {
        ListItem li = Products.Find(obj => obj.Text == productName);
        li.IsChecked = true;
    }

    public void Remove(List<string> productNames)
    {
        int backtrack = 0;
        for (int i = 0; i < Products.Count; i++)
        {
            ListItem li = Products[i];
            if (productNames.Contains(li.Text)) backtrack++;
            else li.Index -= backtrack;
        }
        Products
            .Where(li => productNames.Contains(li.Text))
            .ToList().ForEach(li => Destroy(li.gameObject));
    }
}
