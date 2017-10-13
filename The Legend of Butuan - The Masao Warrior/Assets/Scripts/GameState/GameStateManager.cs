using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {
	
	public GameObject mainCameraPrefab;
	public GameObject canvasPrefab;
	public GameObject playerPrefab;
	public GameObject audioManagerPrefab;

	private Player playerScript;
	private GameObject player;
	private static bool isExists;

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
		playerData = SaveLoadManager.LoadPlayer();
		SceneManager.LoadScene(playerData.currentScene);
		player = Instantiate(playerPrefab);
	}

	void OnEnable() {
		SceneManager.sceneLoaded += OnLevelFinishedLoaded;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnLevelFinishedLoaded;
	}

	void OnLevelFinishedLoaded(Scene scene, LoadSceneMode mode) {
		if(player == null) {
			return;
		}
		SetPlayerStat(playerData);
		Instantiate(canvasPrefab);
		Instantiate(audioManagerPrefab);
		Instantiate(mainCameraPrefab);
	}

	void SetPlayerStat(PlayerData playerData) {
		player.transform.position = new Vector2(playerData.x, playerData.y);
		player.GetComponent<Character>().healthModel.SetHealth(playerData.HP);
		player.GetComponent<Character>().healthModel.SetMaxHealth(playerData.MaxHP);
		player.GetComponent<Character>().levelModel.SetCurrentExp(playerData.XP);
		player.GetComponent<Character>().levelModel.SetCurrentLevel(playerData.Level);
		player.GetComponent<Character>().inventoryModel.SetInventory(playerData.items);
	}

	public void SaveGame() {
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerScript.Save();
	}

}
