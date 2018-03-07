using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HightlightSelection : MonoBehaviour
{
	public Button[] options;
    public GameObject highlight;

    private static int _index = 0;

    void Start()
    {
		_AdvanceIndex(0);
    }

    void Update()
    {
        bool upKey = Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow);
        bool downKey = Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow);
        if (upKey || downKey) _AdvanceIndex(upKey ? -1 : 1);

		bool useKey = Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return);
		if (useKey) options[_index].onClick.Invoke();
    }

    private void _AdvanceIndex(int num)
    {
        _index = (_index + num + options.Count()) % options.Count();
        _SetIndex();
    }

    private void _SetIndex()
    {
        highlight.transform.position = options[_index].transform.position;
    }
}
