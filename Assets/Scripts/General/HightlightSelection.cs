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
    public float offsetY;

    private Vector3 _originalPos;
    private int _index = 0;

    void Start()
    {
        _originalPos = highlight.transform.localPosition;
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
        float posY = _index * offsetY;
        highlight.transform.localPosition = _originalPos + new Vector3(0, posY, 0);
    }
}
