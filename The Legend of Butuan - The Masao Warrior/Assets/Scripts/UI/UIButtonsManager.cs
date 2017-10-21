using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonsManager : MonoBehaviour {

	public AudioSource newGameAudio, loadGameAudio;
	private GameStateManager stateManager;
	private PauseManager pauseManager;

	void Awake() {
		stateManager = GameObject.FindObjectOfType<GameStateManager>() as GameStateManager;
	}
	
	public void NewGame() {
		if(stateManager != null) {
			newGameAudio.Play();
			stateManager.NewGame();
		}
	}

	public void LoadGame() {
		if(stateManager != null) {
			loadGameAudio.Play();
			stateManager.LoadGame();
		}
	}

	public void SaveGame() {
		if(stateManager != null) {
			stateManager.SaveGame();
		}
	}

	public void Respawn() {
		pauseManager.ShowQuestionScreen();
	}

	public void MainMenu() {
		SceneManager.LoadScene("MainMenu");
	}
}
