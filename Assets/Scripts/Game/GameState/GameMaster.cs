﻿using System;
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
		    GuyMovement.Instance.IsInControl = value == GameState.InGame;
            PhoneBehaviors.Instance.IsEnabled = value == GameState.InGame;
            StartOverlay.SetActive(value == GameState.BeforeGame);
            EndOverlay.SetActive(value == GameState.AfterGame);
            _state = value;
        }
    }

    void Start()
    {
        State = GameState.BeforeGame;
    }
}
