using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class EndOverlay : MonoBehaviour
{
    public AudioClip gameOverSound;

    void OnEnable()
    {
        Time.timeScale = 0;
        SoundSource.Instance.Src.PlayOneShot(gameOverSound);
		
		string playerName = PlayerPrefs.GetString("playerName");
		int score = TotalWeightDisplay.Instance.Value;
		StartCoroutine(SendRequest(playerName, score));
    }

    void Update()
    {
        bool restartKey = Input.GetKeyDown(KeyCode.R);
        bool exitKey = Input.GetKeyDown(KeyCode.Escape);

        if (exitKey) SceneManager.LoadScene("MainMenu");
        else if (restartKey) SceneManager.LoadScene("Game");
    }


    IEnumerator SendRequest(string name, int score)
    {
        string requestUrl = "http://mrawesome.cloud:8080/api/score/submit/" + name + "/" + score;
        using (UnityWebRequest www = UnityWebRequest.Get(requestUrl))
        {
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError) Debug.Log(www.error);
            else if (www.isDone)
            {
                PlayerAddResponse response = JsonUtility.FromJson<PlayerAddResponse>(www.downloadHandler.text);
            }
        }
    }
}
