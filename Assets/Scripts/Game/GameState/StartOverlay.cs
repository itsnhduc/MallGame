using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOverlay : MonoBehaviour
{
    public CountdownNumber num;
    public AudioClip countdownSound;

    void Start()
    {
        StartCoroutine(CountDown());
    }

    IEnumerator CountDown()
    {
        SoundSource.Instance.Src.PlayOneShot(countdownSound);
        for (int i = 3; i >= -1; i--)
        {
            if (i == -1) GameMaster.Instance.State = GameMaster.GameState.InGame;
            else num.Text = i != 0 ? i.ToString() : "Start!";
            yield return new WaitForSeconds(1);
        }

    }
}
