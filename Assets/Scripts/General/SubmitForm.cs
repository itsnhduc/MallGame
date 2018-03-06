using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SubmitForm : MonoBehaviour
{
    public Button submitButton;

    void Update()
    {
		bool useKey = Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return);
		if (useKey) submitButton.onClick.Invoke();
    }
}
