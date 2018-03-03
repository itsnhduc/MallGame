using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Scoreboard : MonoBehaviour {

  private const int NO_ITEM_PER_PAGE = 10;
  private const int REFRESH_INTERVAL = 1;

  public GameObject playerScoreboardItemPrefab;
  public Button prevBtn;
  public Button nextBtn;
  public Text pageNumber;

  private List<GameObject> playerScoreboardItems = new List<GameObject>();
  private List<Record> records;
  private int page = 0;
  private int lastPage;

  void Start() {

    for (int i = 0; i < NO_ITEM_PER_PAGE; i++) {
      GameObject go = (GameObject) Instantiate(playerScoreboardItemPrefab, this.transform);
      playerScoreboardItems.Add(go);
      ClearEntry(go);
    }
    StartCoroutine(GetScores());
    prevBtn.onClick.AddListener(PrevPage);
    nextBtn.onClick.AddListener(NextPage);

  }

  IEnumerator GetScores() {
    string requestUrl = "http://mrawesome.cloud:8080/api/score/top";
    while (true) {
      Debug.Log("Sending Request...");
      using (UnityWebRequest www = UnityWebRequest.Get(requestUrl)) {
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError) {
          Debug.Log(www.error);
        } else {
          if (www.isDone) {
            Response response = JsonUtility.FromJson<Response>(www.downloadHandler.text);
            if (response.error != string.Empty) {
              Debug.Log(response.error);
            } else {
              records = response.data;
              int recordLength = records.Count;
              lastPage = recordLength / NO_ITEM_PER_PAGE - (recordLength % NO_ITEM_PER_PAGE != 0 ? 0 : 1);
              ChangePage();
            }
          }
        }
      }
      yield return new WaitForSeconds(REFRESH_INTERVAL);
    }
  }

  void OnDestroy() {
    StopCoroutine(GetScores());
  }

  private bool IsLastPage() {
    return page == lastPage;
  }

  private bool IsFirstPage() {
    return page == 0;
  }

  private void NextPage() {
    if (!IsLastPage()) {
      page++;
    }
    ChangePage();
  }

  private void PrevPage() {
    if (!IsFirstPage()) {
      page--;
    }
    ChangePage();
  }

  private void ChangePage() {
    int startIndex = page * NO_ITEM_PER_PAGE;
    int count = records.Count - startIndex - 1 >= NO_ITEM_PER_PAGE ? NO_ITEM_PER_PAGE : records.Count % NO_ITEM_PER_PAGE;
    List<Record> pageData = records.GetRange(startIndex, count);
    UpdateEntries(pageData);
    UpdatePageNumber();
  }

  private void UpdatePageNumber() {
    DisableButton(prevBtn);
    DisableButton(nextBtn);
    if (!IsFirstPage()) {
      EnableButton(prevBtn);
    }
    if (!IsLastPage()) {
      EnableButton(nextBtn);
    }
    pageNumber.text = (page + 1) + "/" + (lastPage + 1);
  }

  private Text GetInnerText(GameObject go, string name) {
    return go.transform.Find(name).GetComponent<Text>();
  }

  private bool ButtonIsInactive(Button btn) {
    return !btn.gameObject.activeSelf;
  }

  private void DisableButton(Button btn) {
    btn.gameObject.SetActive(false);
  }

  private void EnableButton(Button btn) {
    if (ButtonIsInactive(btn)) {
      btn.gameObject.SetActive(true);
    }
  }

  private void SetEntry(GameObject go, Record record) {
      Text rank = GetInnerText(go, "Rank");
      rank.text = record.rank.ToString();
      Text playerName = GetInnerText(go, "PlayerName");
      playerName.text = record.name;
      Text bestScore = GetInnerText(go, "BestScore");
      bestScore.text = record.bestScore.ToString();
      Text attempt = GetInnerText(go, "Attempt");
      attempt.text = record.attempt.ToString();
  }

  private void ClearEntry(GameObject go) {
      Text rank = GetInnerText(go, "Rank");
      rank.text = string.Empty;
      Text playerName = GetInnerText(go, "PlayerName");
      playerName.text = string.Empty;
      Text bestScore = GetInnerText(go, "BestScore");
      bestScore.text = string.Empty;
      Text attempt = GetInnerText(go, "Attempt");
      attempt.text = string.Empty;
  }

  private void UpdateEntries(List<Record> data) {
    for (int i = 0; i < data.Count; i++) {
      GameObject go = playerScoreboardItems[i];
      Record record = data[i];
      record.rank = page * NO_ITEM_PER_PAGE + i + 1;
      SetEntry(go, record);
    }
    for (int i = data.Count; i < NO_ITEM_PER_PAGE; i++) {
      GameObject go = playerScoreboardItems[i];
      ClearEntry(go);
    }
  }

}
