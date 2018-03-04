using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    public float startSpawnDuration;
    public float spawnDurationDecay;
    public float urgentThreshold;
    // public float deadThreshold;

    public List<Product> products { get; private set; }

    private float _spawnDuration;

    void Start()
    {
        products = FindObjectsOfType<Product>().ToList().OrderBy(p => p.weight).ToList();
        _spawnDuration = startSpawnDuration;
        StartCoroutine(StartSpawning());
    }

    IEnumerator StartSpawning()
    {
        while (true)
        {
            var remainingItems = products.Where(p => !p.Spawned);
            if (remainingItems.Count() > 0)
            {
                PickNextItem(remainingItems).Spawned = true;
            }
            ItemList.Instance.Refresh();
            NewItemMark.Instance.IsShown = true;
            NewItemMark.Instance.IsUrgent = products.Where(p => p.Spawned).Count() >= urgentThreshold;
            yield return new WaitForSeconds(_spawnDuration);
            _spawnDuration -= spawnDurationDecay;
        }
    }

    private Product PickNextItem(IEnumerable<Product> items)
    {
        int nextItemRn = UnityEngine.Random.Range(0, items.Count());
        return items.ElementAt(nextItemRn);
    }
}