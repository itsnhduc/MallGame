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
            SceneManager.LoadScene("Game");
        }
        else
        {
            SceneManager.LoadScene("UserInput");
        }
    }

    public void OnLeaderboard()
    {
        print("Loading Leaderboard...");
        SceneManager.LoadScene("Leaderboard");
    }

    public void OnCredit()
    {
        print("Loading Credit...");
        SceneManager.LoadScene("Credit");
    }

}
