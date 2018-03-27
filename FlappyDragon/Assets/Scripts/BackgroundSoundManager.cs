using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackgroundSoundManager : MonoBehaviour {

	public static BackgroundSoundManager Instance;
	public AudioSource musicAudioSource;
	
	private void Awake(){
		Instance = this;
		
		if(musicAudioSource == null){
			musicAudioSource = gameObject.AddComponent<AudioSource>();
		}
		
	}
	public void PlayMusic(Sound sound){
		musicAudioSource.clip = sound.clip;
		musicAudioSource.volume = sound.volume;
		musicAudioSource.loop = sound.loop;
		musicAudioSource.Play();
	}

	
}
