using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
	void Update ()
	{
		bool escKey = Input.GetKeyDown(KeyCode.Escape);
		if (escKey) SceneManager.LoadScene("MainMenu");
	}
}
