using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : Singleton<GameMaster>
{
    public GameObject StartOverlay;
    public GameObject EndOverlay;
    public GameObject PauseOverlay;

    public enum GameState { BeforeGame, InGame, PausedGame, AfterGame }

    private GameState _state;
    public GameState State
    {
        get { return _state; }
        set
        {
            GuyMovement.Instance.IsInControl = value == GameState.InGame;
            PhoneBehaviors.Instance.IsEnabled = value == GameState.InGame;
            BackgroundMusic.Instance.IsPaused = value == GameState.PausedGame || value == GameState.AfterGame;
            StartOverlay.SetActive(value == GameState.BeforeGame);
            EndOverlay.SetActive(value == GameState.AfterGame);
            PauseOverlay.SetActive(value == GameState.PausedGame);
            _state = value;
        }
    }

    void Start()
    {
        State = GameState.BeforeGame;
    }

    void Update()
    {
        if (State == GameState.InGame && !GuyMovement.Instance.IsHalted && !Product.IsBuying) 
        {
            bool pauseKey = Input.GetKeyDown(KeyCode.Escape);
            if (pauseKey) State = GameState.PausedGame;
        }
    }
}
