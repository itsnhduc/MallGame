using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPage : MonoBehaviour
{
	void Update()
	{
		bool useKey = Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return);
		if (useKey) SceneManager.LoadScene("Game");
	}
}
