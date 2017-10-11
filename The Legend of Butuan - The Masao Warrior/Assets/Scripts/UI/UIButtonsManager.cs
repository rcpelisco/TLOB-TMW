using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonsManager : MonoBehaviour {

	private GameStateManager stateManager;

	void Awake() {
		stateManager = GameObject.FindObjectOfType<GameStateManager>() as GameStateManager;
	}
	
	public void NewGame() {
		if(stateManager != null) {
			stateManager.NewGame();
		}
	}

	public void LoadGame() {
		if(stateManager != null) {
			stateManager.LoadGame();
		}
	}

	public void SaveGame() {
		if(stateManager != null) {
			stateManager.SaveGame();
		}
	}
}
