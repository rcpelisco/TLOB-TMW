using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

	void OnEnable() {
		SceneManager.sceneLoaded += OnLevelFinishLoading;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnLevelFinishLoading;
	}

	void OnLevelFinishLoading(Scene scene, LoadSceneMode mode) {
		string sceneName = SceneManager.GetActiveScene().name;
		if(sceneName == "MainMenu" || sceneName == "TitleScreen") {
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
