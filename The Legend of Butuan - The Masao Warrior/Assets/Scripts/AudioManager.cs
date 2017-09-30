using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public AudioSource BGM;
	
	private static bool isAudioManagerExists;

	void Awake() {
		if(!isAudioManagerExists) {
			isAudioManagerExists = true;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	public void ChangeBGM(AudioClip music)
	{
		BGM.Stop();
		BGM.clip = music;
		BGM.Play();
	}
}
