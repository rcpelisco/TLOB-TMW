 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

	private bool isInventoryActive = false;
	private bool isQuestActive = false;
	private bool isTriviaActive = false;
	private GameObject inventoryScreen;
	private GameObject questScreen;
	private GameObject triviaScreen;

	void Awake() {
		triviaScreen = GameObject.FindGameObjectWithTag("TriviaScreen");
		questScreen = GameObject.FindGameObjectWithTag("QuestScreen");
		inventoryScreen = GameObject.FindGameObjectWithTag("InventoryScreen");
		HideTriviaScreen();
		HideInventoryScreen();
		HideQuestScreen();
	}

	public void InventoryButton() {
		if(isInventoryActive) {
			HideInventoryScreen();
			isInventoryActive = false;
		} else {
			ShowInventoryScreen();
			isInventoryActive = true;
		}
	}

	public void QuestButton() {
		if(isQuestActive) {
			HideQuestScreen();
			isQuestActive = false;
		} else {
			ShowQuestScreen();
			isQuestActive = true;
		}
	}

	public void TriviaToggle() {
		if(isTriviaActive) {
			HideTriviaScreen();
			isTriviaActive = false;
		} else {
			ShowTriviaScreen();
			isTriviaActive = true;
		}
	}

	void ShowInventoryScreen() {
		DoPause();
		if(inventoryScreen != null) {
			inventoryScreen.SetActive(true);
		}
	}

	void HideInventoryScreen() {
		DoUnpause();
		if(inventoryScreen != null) {
			inventoryScreen.SetActive(false);
		}
	}

	void ShowQuestScreen() {
		DoPause();
		if(questScreen != null) {
			questScreen.SetActive(true);
		}
	}

	void HideQuestScreen() {
		DoUnpause();
		if(questScreen != null) {
			questScreen.SetActive(false);
		}
	}

	void ShowTriviaScreen() {
		DoPause();
		if(triviaScreen != null) {
			triviaScreen.SetActive(true);
		}
	}

	void HideTriviaScreen() {
		DoUnpause();
		if(triviaScreen != null) {
			triviaScreen.SetActive(false);
		}
	}

	void DoPause() {
		Time.timeScale = 0;
	}

	void DoUnpause() {
		Time.timeScale = 1;
	}
}
