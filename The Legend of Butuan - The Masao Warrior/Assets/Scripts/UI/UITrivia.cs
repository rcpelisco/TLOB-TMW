using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UITrivia : MonoBehaviour {

	public Trivia[] trivias;
	public Text triviaText; 

	private PauseManager pauseManager;

	void Awake() {
		pauseManager = GameObject.Find("Canvas").GetComponent<PauseManager>();
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		foreach(Trivia trivia in trivias) {
			if(GetCurrentScenName() == trivia.area) {
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
		yield return new WaitForSeconds(1.25f);
		pauseManager.TriviaToggle();
		triviaText.text = trivia.trivia;
	}
}
