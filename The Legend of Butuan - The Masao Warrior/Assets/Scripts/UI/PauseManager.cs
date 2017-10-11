using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PauseManager : MonoBehaviour {

	private bool isInventoryActive = false;
	private bool isQuestActive = false;
	private bool isTriviaActive = false;
	private bool isPauseActive = false;
	private bool isBookActive = false;
	private GameObject inventoryScreen;
	private GameObject questScreen;
	private GameObject triviaScreen;
	private GameObject pauseScreen;
	private GameObject bookScreen;
	private GameObject bookButton;
	private CharacterInventoryModel inventoryModel;
	
	void Awake() {
		inventoryModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInventoryModel>();
		triviaScreen = GameObject.FindGameObjectWithTag("TriviaScreen");
		questScreen = GameObject.FindGameObjectWithTag("QuestScreen");
		inventoryScreen = GameObject.FindGameObjectWithTag("InventoryScreen");
		pauseScreen = GameObject.FindGameObjectWithTag("PauseMenu");
		bookScreen = GameObject.FindGameObjectWithTag("BookScreen");
		bookButton = GameObject.FindGameObjectWithTag("BookButton");
		HideTriviaScreen();
		HideInventoryScreen();
		HideQuestScreen();
		HidePauseScreen();
		HideBookScreen();
	}

	void Start() {
		if(bookButton != null) {
			bookButton.SetActive(false);
		}
	}

	void Update() {
		if(inventoryModel.HasItem(ItemType.Book)) {
			bookButton.SetActive(true);
		}
	}


	public void Mute() 
	{
		AudioListener.pause = !AudioListener.pause;

	}

	public void BookButton() {
		if(isBookActive) {
			HideBookScreen();
			isBookActive = false;
		} else {
			ShowBookScreen();
			isBookActive = true;
		}
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

	public void PauseButton() {
		if(isPauseActive) {
			HidePauseScreen();
			isPauseActive = false;
		} else {
			ShowPauseScreen();
			isPauseActive = true;
		}
	}

	void ShowBookScreen() {
		DoPause();
		if(bookScreen != null) {
			bookScreen.SetActive(true);
		}
	}

	void HideBookScreen() {
		DoUnpause();
		if(bookScreen != null) {
			bookScreen.SetActive(false);
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

	void ShowPauseScreen() {
		DoPause();
		if(pauseScreen != null) {
			pauseScreen.SetActive(true);
		}
	}

	void HidePauseScreen() {
		DoUnpause();
		if(pauseScreen != null) {
			pauseScreen.SetActive(false);
		}
	}

	void DoPause() {
		Time.timeScale = 0;
	}

	void DoUnpause() {
		Time.timeScale = 1;
	}

	public void MainMenuScreen() {
		DoUnpause();
		Application.LoadLevel("MainMenu");
	}

	public void QuitGame() {
		Application.Quit();
	}
}
