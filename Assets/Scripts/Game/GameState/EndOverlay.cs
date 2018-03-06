using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndOverlay : MonoBehaviour
{
	public AudioClip gameOverSound;

	void Start()
	{
		Time.timeScale = 0;
	}

	void Update()
	{
		SoundSource.Instance.Src.PlayOneShot(gameOverSound);
	}
}
