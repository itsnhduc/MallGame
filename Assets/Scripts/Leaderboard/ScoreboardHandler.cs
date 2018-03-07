using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreboardHandler : MonoBehaviour {

  public Scoreboard scoreboard;

  public void OnMainMenu() {
    scoreboard.OnMainMenu();
  }

  public void OnPrev() {
    scoreboard.PrevPage();
  }

  public void OnNext() {
    scoreboard.NextPage();
  }

}
