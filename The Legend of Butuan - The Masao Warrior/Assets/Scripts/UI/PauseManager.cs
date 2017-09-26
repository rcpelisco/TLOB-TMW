 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

	private bool isScreenActive = false;
	private GameObject inventoryScreen;
	private GameObject questScreen;

	void Awake() {
		questScreen = GameObject.FindGameObjectWithTag("QuestScreen");
		inventoryScreen = GameObject.FindGameObjectWithTag("InventoryScreen");
		HideInventoryScreen();
		HideQuestScreen();
	}

	public void InventoryButton() {
		if(isScreenActive) {
			HideInventoryScreen();
			isScreenActive = false;
		} else {
			ShowInventoryScreen();
			isScreenActive = true;
		}
	}

	public void QuestButton() {
		if(isScreenActive) {
			HideQuestScreen();
			isScreenActive = false;
		} else {
			ShowQuestScreen();
			isScreenActive = true;
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

	void DoPause() {
		Time.timeScale = 0;
	}

	void DoUnpause() {
		Time.timeScale = 1;
	}
}
