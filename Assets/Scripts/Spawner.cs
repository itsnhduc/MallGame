using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<Product> products { get; private set; }

    public static Spawner Instance { get { return FindObjectOfType<Spawner>(); } }

    void Start()
    {
        products = FindObjectsOfType<Product>().ToList().OrderBy(p => p.weight).ToList();
        ItemList.Instance.Refresh();
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        // do stuff
        yield return null;
    }
}