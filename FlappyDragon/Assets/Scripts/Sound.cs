﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Sound{


	public AudioClip clip;
	[Range(0,1f)]
	public float volume;
	public bool loop; 
}
