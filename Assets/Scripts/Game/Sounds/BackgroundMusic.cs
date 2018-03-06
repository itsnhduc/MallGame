using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : Singleton<BackgroundMusic>
{
	public float modifier;
    public AudioClip scratchSound;
    public float fadeInAmount;

    AudioSource src { get { return GetComponent<AudioSource>(); } }

    public float Pitch { set { src.pitch = Mathf.Pow(value, modifier); } }

    public bool IsPaused
    {
        set
        {
            if (value)
            {
                src.Pause();
                src.volume = 0;
            }
            else
            {
                src.UnPause();
                StartCoroutine(FadeIn());
            }
        }
    }

    public bool IsScratched
    {
        set
        {
            IsPaused = value;
            if (value) SoundSource.Instance.Src.PlayOneShot(scratchSound);
        }
    }

    IEnumerator FadeIn()
    {
        while (src.volume < 1)
        {
            src.volume += fadeInAmount;
            yield return new WaitForFixedUpdate();
        }
    }
}
