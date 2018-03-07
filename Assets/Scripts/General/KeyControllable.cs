using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyControllable : MonoBehaviour
{
    public KeyCode[] keyOptions;

    void Update()
    {
        foreach (KeyCode k in keyOptions)
        {
            if (Input.GetKeyDown(k))
            {
                GetComponent<Button>().onClick.Invoke();
            }
        }
    }
}
