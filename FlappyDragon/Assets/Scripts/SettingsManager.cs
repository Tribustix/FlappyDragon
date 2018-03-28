using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour {

	public static GameObject backgroundMusicObject;

	public void SetVolume(float volume){
		BackgroundSoundManager.Instance.SetVolume(volume);
	}	
}
