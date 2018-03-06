using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CreditScene : MonoBehaviour {

  public Button mainMenuBtn;

	void Start () {

    mainMenuBtn.onClick.AddListener(OnMainMenu);
		
	}

  private void OnMainMenu() {
    Debug.Log("Back To Main Menu");
    SceneManager.LoadScene("MainMenu");
  }
	
}
