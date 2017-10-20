using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	private Character playerStats;

	[HideInInspector]
	public float HP;
	[HideInInspector]
	public float MaxHP;
	[HideInInspector]
	public int Level;
	[HideInInspector]
	public int XP;
	[HideInInspector]
	public string currentScene;
	[HideInInspector]
	public float x;
	[HideInInspector]
	public float y;
	[HideInInspector]
	public Dictionary<ItemType, int> items;
	[HideInInspector]
	public QuestData mainQuest;
	[HideInInspector]
	public List<QuestData> sideQuests;

	void Awake() {
		sideQuests = new List<QuestData>();
		playerStats = GetComponent<Character>();
		DontDestroyOnLoad(gameObject);
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		string sceneName = SceneManager.GetActiveScene().name;
		if(sceneName == "MainMenu" || sceneName == "GameOver") {
			// Destroy(gameObject);
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

	void NewPlayerStats() {
		HP = 100f;
		MaxHP = 100f;
		Level = 1;
		XP = 0;
		x = 28.55f;
		y = -2.5f;
		
	}
	void NewPlayerInventory() {
		items = new Dictionary<ItemType, int>();
	}
	void NewPlayerQuest() {
		mainQuest = new QuestData();
		sideQuests = new List<QuestData>();
	}

	void SavePlayerInventory() {
		items = playerStats.inventoryModel.GetInventory();
	}

	void SavePlayerQuest() {
		mainQuest = playerStats.questModel.GetMainQuest();
		sideQuests = playerStats.questModel.GetSideQuest();
	}

	public void NewPlayer() {
		NewPlayerStats();
		NewPlayerQuest();
		NewPlayerInventory();
		currentScene = "JoelHouseGame";
	}

	public void Save() {
		SavePlayerStats();
		SavePlayerInventory();
		SavePlayerQuest();
		currentScene = SceneManager.GetActiveScene().name;
	}

	public void CommitSave() {
		SaveLoadManager.SavePlayer(this);
	}

	public void ResetHealth() {
		HP = playerStats.healthModel.GetMaxHealth();
	}

	void OnDestroy() {
		Debug.Log("Destroyed: " + SceneManager.GetActiveScene().name);
	}
}
