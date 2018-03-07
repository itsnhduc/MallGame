using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    void Start()
    {
        if (Debug.isDebugBuild)
        {
            print("Initializing game in Development...");
            PlayerPrefs.DeleteAll();
        }

    }

    public void OnStartGame()
    {
        if (PlayerPrefs.HasKey("playerName"))
        {
            string playerName = PlayerPrefs.GetString("playerName");
            print("Starting Game as " + playerName + "...");
            _LoadScene("Game");
        }
        else
        {
            _LoadScene("UserInput");
        }
    }

    public void OnLeaderboard()
    {
        _LoadScene("Leaderboard");
    }

    public void OnCredit()
    {
        _LoadScene("Credit");
    }

    private void _LoadScene(string sceneName)
    {
        print("Loading " + sceneName + "...");
        SceneManager.LoadScene(sceneName);
    }

}
