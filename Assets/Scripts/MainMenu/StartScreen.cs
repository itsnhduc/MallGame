using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

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

    IEnumerator SendRequest(string name)
    {
        string requestUrl = "http://mrawesome.cloud:8080/api/player/add/" + name;
        using (UnityWebRequest www = UnityWebRequest.Get(requestUrl))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                if (www.isDone)
                {
                    PlayerAddResponse response = JsonUtility.FromJson<PlayerAddResponse>(www.downloadHandler.text);
                    if (response.error != string.Empty) {
                      Debug.Log(response.error);
                    } else {
                      Debug.Log(response.data.name);
                    }
                }
            }
        }
    }

    public void OnStartGame()
    {
        if (PlayerPrefs.HasKey("playerName"))
        {
            string playerName = PlayerPrefs.GetString("playerName");
            print("Starting Game as " + playerName + "...");
            IEnumerator coroutine = SendRequest(playerName);
            StartCoroutine(coroutine);
            _LoadScene("Game");
        }
        else
        {
            _LoadScene("UserInput");
        }
    }

    public void OnTutorials() {
        _LoadScene("Tutorials");
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
