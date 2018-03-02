using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogService : MonoBehaviour
{
	public const float ShortDuration = 0.8f;

    Text t { get { return GetComponent<Text>(); } }
	
    public static DialogService Instance() { return FindObjectOfType<DialogService>(); }

    public string DialogText
    {
        get { return t.text; }
        set { t.text = value; }
    }

	private IEnumerator _thread;

    void Start()
    {
        t.text = string.Empty;
    }

	public void Clear()
	{
		Show(string.Empty);
	}

    public void Show(string text, float duration = 0)
    {
        if (DialogText != string.Empty) StopCoroutine(_thread);
		_thread = Display(text, duration);
		StartCoroutine(_thread);
    }

    IEnumerator Display(string dialogText, float duration)
    {
        DialogText = dialogText;
		if (duration == 0) yield return null;
		else
		{
			yield return new WaitForSeconds(duration);
			DialogText = string.Empty;
		}
    }
}
