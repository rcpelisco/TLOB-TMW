using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {
	
	public GameObject mainCameraPrefab;
	public GameObject canvasPrefab;
	public GameObject playerPrefab;
	public GameObject audioManagerPrefab;

	private GameObject player;
	private GameObject cam;
	private GameObject canvas;
	private GameObject audioManager;
	private static bool isExists;
	private bool fromRespawn;
	private bool load;

	private PlayerData playerData;

	void Awake() {
		if(!isExists) {
			isExists = true;
			DontDestroyOnLoad(gameObject);
		}else {
			Destroy(gameObject);
		}
	}

	public void NewGame() {
		SceneManager.LoadScene("IntroNarration");
	}

	public void LoadGame() {
		load = true;
		playerData = SaveLoadManager.LoadPlayer();
		SceneManager.LoadScene(playerData.currentScene);
	}

	void OnEnable() {
		Debug.Log("OnEnableLoad");
		SceneManager.sceneLoaded += OnLevelFinishedLoaded;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnLevelFinishedLoaded;
	}

	void OnLevelFinishedLoaded(Scene scene, LoadSceneMode mode) {
		if(load) {
			player = Instantiate(playerPrefab);
			canvas = Instantiate(canvasPrefab);
			SetPlayerStat(playerData);
			audioManager = Instantiate(audioManagerPrefab);
			cam = Instantiate(mainCameraPrefab);
			load = false;
			Debug.Log(string.Format("player: {0}, canvas: {1}, audioManager: {2}, cam: {3}", 
				player.name, canvas.name, 
				audioManager.name, cam.name));

		}
	}

	void SetPlayerStat(PlayerData playerData) {
		player.GetComponent<Character>().healthModel.SetHealth(playerData.HP);
		player.GetComponent<Character>().healthModel.SetMaxHealth(playerData.MaxHP);
		player.GetComponent<Character>().levelModel.SetCurrentExp(playerData.XP);
		player.GetComponent<Character>().levelModel.SetCurrentLevel(playerData.Level);
		player.GetComponent<Character>().inventoryModel.SetInventory(playerData.items);
		fromRespawn = false;
	}

	public void SaveGame() {	
		Player playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerScript.Save();
		playerScript.CommitSave();
	}

	public void RespawnSave() {
		Player playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerScript.Save();
		playerScript.ResetHealth();
		playerScript.CommitSave();
		SceneManager.LoadScene("GameOver");
	}

	public string GetCurrentScene() {
		return playerData.currentScene;
	}
}
