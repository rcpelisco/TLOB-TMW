using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
	private GameObject gameOverScreen;

	private GameObject bookButton;

	private Animator pauseAnim;
	private CharacterInventoryModel inventoryModel;
	
	void Awake() {
		if(GameObject.FindGameObjectWithTag("Player") != null) {
			inventoryModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInventoryModel>();
		}
		triviaScreen = GameObject.FindGameObjectWithTag("TriviaScreen");
		questScreen = GameObject.FindGameObjectWithTag("QuestScreen");
		inventoryScreen = GameObject.FindGameObjectWithTag("InventoryScreen");
		pauseScreen = GameObject.FindGameObjectWithTag("PauseMenu");
		bookScreen = GameObject.FindGameObjectWithTag("BookScreen");
		bookButton = GameObject.FindGameObjectWithTag("BookButton");
		gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen");

		HideTriviaScreen();
		HideInventoryScreen();
		HideQuestScreen();
		HidePauseScreen();
		HideBookScreen();
		HideGameOverScreen();
	}

	void Start() {
		if(bookButton != null) {
			bookButton.SetActive(false);
		}
	}

	void Update() {
		if(inventoryModel == null) {
			inventoryModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInventoryModel>();
		}
		if(inventoryModel.HasItem(ItemType.Book)) {
			bookButton.SetActive(true);
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
		if(sceneName == "MainMenu" || sceneName == "GameOver") {
			Destroy(gameObject);
		}
	}

	public void Mute() {
		AudioListener.pause = !AudioListener.pause;
	}

	public void ShowGameOverScreen() {
		if(gameOverScreen != null) {
			gameOverScreen.SetActive(true);
		}
	}

	public void HideGameOverScreen() {
		if(gameOverScreen != null) {
			gameOverScreen.SetActive(false);
		}
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
			pauseAnim.Play("HIde");
			isPauseActive = false;
		} else {
			ShowPauseScreen();
			pauseAnim.Play("View");
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
			pauseAnim = pauseScreen.GetComponentInChildren<Animator>();
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
		SceneManager.LoadScene("MainMenu" );
	}

	public void QuitGame() {
		Application.Quit();
	}
}
