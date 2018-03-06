using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListItem : MonoBehaviour
{
    public const float offsetY = -55f;

    Text t { get { return transform.Find("ListItemText").GetComponent<Text>(); } }
    GameObject checkUI { get { return transform.Find("Checked").gameObject; } }
    Image icon { get { return transform.Find("Icon").GetComponent<Image>(); } }

    public string Text
    {
        get { return t.text; }
        set { t.text = value; }
    }

    public bool IsChecked
    {
        get { return checkUI.activeSelf; }
        set { checkUI.SetActive(value); }
    }

    public Sprite Icon { set { icon.sprite = value; } }

    private int _index;
    public int Index
    {
        get { return _index; }
        set
        {
            transform.localPosition = new Vector2(0, value * offsetY);
            _index = value;
        }
    }
}
