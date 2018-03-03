using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCount : MonoBehaviour
{
    Text t { get { return GetComponent<Text>(); } }
    public static ItemCount Instance { get { return FindObjectOfType<ItemCount>(); } }

    public int Count { set { t.text = value.ToString(); } }
}
