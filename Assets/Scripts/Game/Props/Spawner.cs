using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Singleton<Spawner>
{
    public float startingSpawnDelay;
    public float startSpawnDuration;
    public float minSpawnDuration;
    public float spawnDurationDecay;
    public float urgentThreshold;
    public float deadThreshold;
    public AudioClip newItemSound;

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
        yield return new WaitForSeconds(startingSpawnDelay);
        while (true)
        {
            var remainingItems = products.Where(p => !p.Spawned);
            if (remainingItems.Count() > 0)
            {
                Product nextItem = PickNextItem(remainingItems);
                nextItem.Spawned = true;
                ItemList.Instance.Add(nextItem.productName, nextItem.icon);
                NewItemMark.Instance.IsShown = true;
                int spawnedCount = products.Where(p => p.Spawned).Count();
                NewItemMark.Instance.IsUrgent = spawnedCount > urgentThreshold;
                if (spawnedCount > deadThreshold)
                {
                    GameMaster.Instance.State = GameMaster.GameState.AfterGame;
                }
                SoundSource.Instance.Src.PlayOneShot(newItemSound);
            }
            yield return new WaitForSeconds(_spawnDuration);
            if (_spawnDuration > minSpawnDuration)
            {
                _spawnDuration = Mathf.Max(_spawnDuration - spawnDurationDecay, minSpawnDuration);
            }
        }
    }

    private Product PickNextItem(IEnumerable<Product> items)
    {
        int nextItemRn = UnityEngine.Random.Range(0, items.Count());
        return items.ElementAt(nextItemRn);
    }
}