using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class InputValidator : MonoBehaviour {

  private const int NAME_LENGTH_LOWER_LIMIT = 5;
  private const int NAME_LENGTH_UPPER_LIMIT = 20;
  private const string SUBMIT_BTN_LABEL = "Let's Start";
  private string DEFAULT_NAME_HINT = "name must be " + NAME_LENGTH_LOWER_LIMIT + "-" + NAME_LENGTH_UPPER_LIMIT + " alphanumeric characters";
  private const string INAPPROPRIATE_LENGTH_HINT = "inappropriate length";
  private const string ILLEGAL_CHARACTERS = "illegal characters";

  private static Color INPUT_FIELD_NO_WARNING = Color.white;
  private static Color INPUT_FIELD_INVALID_NAME = Color.red;
  private static Regex NAME_FORMAT = new Regex("[A-Za-z0-9]+");

  public Button submitBtn;
  public InputField playerNameInput;
  public GameObject progressCircle;
  public Text playerNameHint;

	void Start () {
    SetButtonText(submitBtn, SUBMIT_BTN_LABEL);
    submitBtn.onClick.AddListener(SubmitPlayerName);
    playerNameInput.characterLimit = NAME_LENGTH_UPPER_LIMIT;
    progressCircle.SetActive(false);
    SetHintText(DEFAULT_NAME_HINT);
	}

  void Update() {
    if (playerNameInput.isFocused) {
      ChangeInputFieldBackgroundColor(true);
      SetHintText(DEFAULT_NAME_HINT);
    }
  }

  private void SetButtonText(Button btn, string label) {
    btn.GetComponentInChildren<Text>().text = label;
  }

  private void SetHintText(string hint) {
    playerNameHint.text = hint.ToLower();
  }
  
  private void RequestInProgress() {
    SetButtonText(submitBtn, string.Empty);
    progressCircle.SetActive(true);
  }

  private void RequestCompleted() {
    SetButtonText(submitBtn, SUBMIT_BTN_LABEL);
    progressCircle.SetActive(false);
  }

  private bool ValidatePlayerName(string name) {
    int nameLength = name.Length;
    if (nameLength < 5 || nameLength > 20) {
      SetHintText(INAPPROPRIATE_LENGTH_HINT);
      return false;
    }
    MatchCollection matches = NAME_FORMAT.Matches(name);
    if (matches.Count == 0) {
      SetHintText(ILLEGAL_CHARACTERS);
      return false;
    }
    string matchedName = matches[0].Captures[0].Value;
    if (matchedName != name) {
      SetHintText(ILLEGAL_CHARACTERS);
      return false;
    }
    return true;
  }

  private void ChangeInputFieldBackgroundColor(bool isValidName) {
    Image background = playerNameInput.GetComponent<Image>();
    if (isValidName) {
      background.color = INPUT_FIELD_NO_WARNING;
    } else {
      background.color = INPUT_FIELD_INVALID_NAME;
    }
  }

  IEnumerator SendRequest(string name) {
    RequestInProgress();
    string requestUrl = "http://mrawesome.cloud:8080/api/player/add/" + name;
    using (UnityWebRequest www = UnityWebRequest.Get(requestUrl)) {
      yield return www.SendWebRequest();
      if (www.isNetworkError || www.isHttpError) {
        Debug.Log(www.error);
        SetHintText(www.error);
      } else {
        if (www.isDone) {
          PlayerAddResponse response = JsonUtility.FromJson<PlayerAddResponse>(www.downloadHandler.text);
          HandleResponse(response);
        }
      }
    }
  }

  private void HandleResponse(PlayerAddResponse response) {
    if (response.error != string.Empty) {
      Debug.Log(response.error);
      SetHintText(response.error);
      ChangeInputFieldBackgroundColor(false);
      RequestCompleted();
    } else {
      PlayerPrefs.SetString("playerName", response.data.name);
      SceneManager.LoadScene("Game");
    }
  }

  private void SubmitPlayerName() {
    string submittedName = playerNameInput.text;
    bool isValidName = ValidatePlayerName(submittedName);
    ChangeInputFieldBackgroundColor(isValidName);
    if (isValidName) {
      IEnumerator coroutine = SendRequest(submittedName);
      StartCoroutine(coroutine);
    }
  }
	
}
