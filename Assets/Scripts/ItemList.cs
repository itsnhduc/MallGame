using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : Singleton<ItemList>
{
    public GameObject listItemPrefab;
    public float speed;
    public int minScrollNumber;

    Rigidbody2D rb { get { return GetComponent<Rigidbody2D>(); } }

    public Vector2 MoveDirection { set { rb.velocity = value * speed; } }

    private Vector2 _originalLocalPos;

    private bool _isScrollable = false;

    void Start()
    {
        _originalLocalPos = transform.localPosition;
    }

    void Update()
    {
        if (_isScrollable)
        {
            bool upKey = Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W);
            bool downKey = Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S);
            if (upKey || downKey) MoveDirection = upKey ? Vector2.up : Vector2.down;
            else MoveDirection = Vector2.zero;
            if (transform.localPosition.y < _originalLocalPos.y)
            {
                MoveDirection = Vector2.zero;
                transform.localPosition = _originalLocalPos;
            }
        }
    }

    public void Refresh()
    {
        _Clear();
        _Render();
    }

    private void _Clear()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "ListItem") Destroy(child.gameObject);
        }
    }
    private void _Render()
    {
        // transform.localPosition = _originalLocalPos;
        var guyItems = GuyMovement.Instance.GetComponent<ItemStorage>().items;
        var remainingItems = Spawner.Instance.products.Where(p => p.Spawned);
        var guyItemInfo = guyItems.Select(p => new KeyValuePair<Product, bool>(p, true));
        var remainingItemsInfo = remainingItems.Select(p => new KeyValuePair<Product, bool>(p, false));
        var totalItemInfo = guyItemInfo.Concat(remainingItemsInfo);
        for (int i = 0; i < totalItemInfo.Count(); i++)
        {
            GameObject newItemList = Instantiate(listItemPrefab, transform);
            var targetProduct = totalItemInfo.ElementAt(i);
            ListItem li = newItemList.GetComponent<ListItem>();
            li.Index = i;
            li.Text = targetProduct.Key.productName;
            li.IsChecked = targetProduct.Value;
            li.Icon = targetProduct.Key.icon;
        }
        ItemCount.Instance.Count = totalItemInfo.Count();
        _isScrollable = totalItemInfo.Count() >= minScrollNumber;
    }
}
