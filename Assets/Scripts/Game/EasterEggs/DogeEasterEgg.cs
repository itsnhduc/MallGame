using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogeEasterEgg : MonoBehaviour
{
	public GameObject overlay;
    public Doge doge;
    public Weed weed;
	public AudioClip dogeSound;
    public float triggerSpeed;
    public float delayTime;
	public float duration;

    private bool _hasTriggerd = false;

    void Update()
    {
        if (!_hasTriggerd && GuyMovement.Instance.TrueSpeed <= triggerSpeed)
        {
            StartCoroutine(Activate());
        }
    }

    IEnumerator Activate()
    {
		_hasTriggerd = true;
        yield return new WaitForSeconds(delayTime);
		BackgroundMusic.Instance.IsPaused = true;
		SoundSource.Instance.Src.PlayOneShot(dogeSound);
		overlay.SetActive(true);
        doge.Activate();
		weed.Activate();
		yield return new WaitForSeconds(duration);
		overlay.SetActive(false);
		SoundSource.Instance.Src.Stop();
		BackgroundMusic.Instance.IsPaused = false;
		doge.Deactivate();
		weed.Deactivate();
    }
}
