 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {

	private bool isInventoryScreenActive = false;
	private GameObject inventoryScreen;

	void Awake() {
		inventoryScreen = GameObject.FindGameObjectWithTag("InventoryScreen");
		HideInventoryScreen();
	}

	public void InventoryButton() {
		if(isInventoryScreenActive) {
			HideInventoryScreen();
			isInventoryScreenActive = false;
		} else {
			ShowInventoryScreen();
			isInventoryScreenActive = true;
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

	void DoPause() {
		Time.timeScale = 0;
	}

	void DoUnpause() {
		Time.timeScale = 1;
	}
}
