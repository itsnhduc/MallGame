using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseOverlay : MonoBehaviour
{
	void Start()
	{
		Time.timeScale = 0;
	}

    void Update()
    {
		bool resumeKey = Input.GetKeyDown(KeyCode.Escape);
		bool restartKey = Input.GetKeyDown(KeyCode.R);
		if (resumeKey)
		{
			GameMaster.Instance.State = GameMaster.GameState.InGame;
			Time.timeScale = 1;
		}
		else if (restartKey)
		{
			SceneManager.LoadScene("Game");
		}
    }
}
