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
		bool forwardKey = Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow);
        bool backwardKey = Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow);
        if (forwardKey)
        {
            if (curPage < 6)
            {
                tutPages[curPage].gameObject.SetActive(false);
                curPage++;
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
        if (backwardKey)
        {
            if (curPage > 0)
            {
                tutPages[curPage].gameObject.SetActive(false);
                curPage--;
                tutPages[curPage].gameObject.SetActive(true);
            }
        }
    }
}
