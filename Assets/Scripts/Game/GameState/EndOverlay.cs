using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOverlay : MonoBehaviour
{
	public AudioClip gameOverSound;

	void OnEnable()
	{
		Time.timeScale = 0;
		SoundSource.Instance.Src.PlayOneShot(gameOverSound);
	}

	void Update()
	{
		bool restartKey = Input.GetKeyDown(KeyCode.R);
		bool exitKey = Input.GetKeyDown(KeyCode.Escape);
		
		if (exitKey) SceneManager.LoadScene("MainMenu");
		else if (restartKey) SceneManager.LoadScene("Game");
	}
}
