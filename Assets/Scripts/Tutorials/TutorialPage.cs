using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPage : MonoBehaviour
{
    public Canvas[] tutPages;
    private int curPage = 0;

    void Update()
	{
		bool useKey = Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return);
		if (useKey)
        {
            if (curPage < 6)
            {
                tutPages[curPage].gameObject.SetActive(false);
                curPage++;
                print(curPage);
                tutPages[curPage].gameObject.SetActive(true);
            }
            else
            {
                tutPages[curPage].gameObject.SetActive(false);
                curPage = 0;
                tutPages[curPage].gameObject.SetActive(true);
                SceneManager.LoadScene("MainMenu");
            }
        }
	}
}
