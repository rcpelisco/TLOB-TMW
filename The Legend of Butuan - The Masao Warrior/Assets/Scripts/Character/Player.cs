using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	private static bool isPlayerExists;
	private Character playerStats;

	public float HP;
	public float MaxHP;
	public int Level;
	public int XP;
	public string currentScene;
	public float x;
	public float y;
	public Dictionary<ItemType, int> items;

	void Awake() {
		playerStats = GetComponent<Character>();
		if(!isPlayerExists) {
			isPlayerExists = true;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		string sceneName = SceneManager.GetActiveScene().name;
		if(sceneName == "MainMenu" || sceneName == "TitleScreen") {
			Destroy(gameObject);
		}
	}

	void OnEnable() {
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void Ondisable() {
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

	void SavePlayerStats() {
		HP = playerStats.healthModel.GetHealth();
		MaxHP = playerStats.healthModel.GetMaxHealth();
		Level = playerStats.levelModel.GetCurrentLevel();
		XP = playerStats.levelModel.GetCurrentExp();
		x = transform.position.x;
		y = transform.position.y;
	}

	void SavePlayerInventory() {
		items = playerStats.inventoryModel.GetInventory();
	}

	public void Save() {
		SavePlayerStats();
		SavePlayerInventory();
		currentScene = SceneManager.GetActiveScene().name;
		SaveLoadManager.SavePlayer(this);
	}
}
