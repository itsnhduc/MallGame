using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSource : Singleton<SoundSource>
{
    public AudioSource Src { get { return GetComponent<AudioSource>(); } }
}
