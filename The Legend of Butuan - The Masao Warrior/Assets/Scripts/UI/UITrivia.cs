using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITrivia : MonoBehaviour {

	public Trivia[] trivias;
	public Text triviaText; 

	public PauseManager pauseManager;
	
	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		foreach(Trivia trivia in trivias) {
			if(GetCurrentScenName() == trivia.area) {
				Debug.Log(GetCurrentScenName());
				StartCoroutine(DelayShow(trivia));
			}
		}
	}

	string GetCurrentScenName() {
		Scene scene = SceneManager.GetActiveScene();
		return scene.name;
	}

	void OnEnable() {
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	IEnumerator DelayShow(Trivia trivia) {
		yield return new WaitForSeconds(3f);
		pauseManager.TriviaToggle();
		triviaText.text = trivia.trivia;
	}
}
