using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOverlay : MonoBehaviour
{
	void Update()
	{
		if (Input.anyKey) GameMaster.Instance.State = GameMaster.GameState.InGame;
	}
}
