using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : Singleton<GameMaster>
{
    public GameObject StartOverlay;
    public GameObject EndOverlay;

    public enum GameState { BeforeGame, InGame, AfterGame }

    private GameState _state;
    public GameState State
    {
        get { return _state; }
        set
        {
            Time.timeScale = (State == GameState.InGame ? 1 : 0);
            StartOverlay.SetActive(State == GameState.BeforeGame);
            EndOverlay.SetActive(State == GameState.AfterGame);
            _state = value;
        }
    }

    void Start()
    {
        State = GameState.BeforeGame;
    }
}
