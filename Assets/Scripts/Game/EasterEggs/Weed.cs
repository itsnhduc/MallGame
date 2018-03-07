using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weed : MonoBehaviour
{
    public void Activate()
    {
		GetComponentsInChildren<WeedLeaf>().ToList().ForEach(l => l.Activate());
    }

    public void Deactivate()
    {
        Destroy(gameObject);
    }
}
