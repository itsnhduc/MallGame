using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour {

  public Button startGameBtn;
  public Button leaderboardBtn;
  public Button exitGameBtn;

	// Use this for initialization
	void Start () {

    startGameBtn.onClick.AddListener(OnStartGame);
    leaderboardBtn.onClick.AddListener(OnLeaderboard);
    exitGameBtn.onClick.AddListener(OnExitGame);
		
	}

  private void OnStartGame() {
    Debug.Log("Starting Game...");
    SceneManager.LoadScene("Game");
  }

  private void OnLeaderboard() {
    Debug.Log("Loading Leaderboard...");
    SceneManager.LoadScene("Leaderboard");
  }

  private void OnExitGame() {
    Debug.Log("Exiting Game...");
    Application.Quit();
  }
}
