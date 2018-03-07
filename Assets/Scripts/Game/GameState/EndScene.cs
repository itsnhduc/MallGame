using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class EndScene : MonoBehaviour
{

    public Sprite[] sprites;
    // Use this for initialization
    public void SetEndScene(int weight)
    {
        if (weight < 40)
        {
            GetComponent<Image>().sprite = sprites[0];
        }
        else if (weight < 80)
        {
            GetComponent<Image>().sprite = sprites[1];
        }
        else if (weight < 100)
        {
            GetComponent<Image>().sprite = sprites[2];
        }
        else
        {
            GetComponent<Image>().sprite = sprites[3];
        }
    }
}
