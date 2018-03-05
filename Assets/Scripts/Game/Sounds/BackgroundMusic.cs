using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : Singleton<BackgroundMusic>
{
	public float modifier;

    AudioSource src { get { return GetComponent<AudioSource>(); } }

    public float Pitch { set { src.pitch = Mathf.Pow(value, modifier); } }
}
