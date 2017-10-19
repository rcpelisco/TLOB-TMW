using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	void OnEnable() {
		SceneManager.sceneLoaded += LoadArea;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= LoadArea;
	}

	void LoadArea(Scene scene, LoadSceneMode mode) {
		SceneManager.LoadScene("LoadArea");
	}
}
