using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

  public Button startGameBtn;
  public Button leaderboardBtn;
  public Button creditBtn;

	// Use this for initialization
	void Start () {

    startGameBtn.onClick.AddListener(OnStartGame);
    leaderboardBtn.onClick.AddListener(OnLeaderboard);
    creditBtn.onClick.AddListener(OnCredit);
    if (Debug.isDebugBuild) {
      Debug.Log("Initializing game in Development...");
      PlayerPrefs.DeleteAll();
    }
		
	}

  private void OnStartGame() {
    if (PlayerPrefs.HasKey("playerName")) {
      string playerName = PlayerPrefs.GetString("playerName");
      Debug.Log("Starting Game as " + playerName + "...");
      SceneManager.LoadScene("Game");
    } else {
      SceneManager.LoadScene("UserInput");
    }
  }

  private void OnLeaderboard() {
    Debug.Log("Loading Leaderboard...");
    SceneManager.LoadScene("Leaderboard");
  }

  private void OnCredit() {
    Debug.Log("Loading Credit...");
    SceneManager.LoadScene("Credit");
  }

}
