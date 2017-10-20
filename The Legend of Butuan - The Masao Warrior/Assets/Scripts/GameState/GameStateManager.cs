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
	private bool load;

	private PlayerData playerData;

	void Awake() {
		DontDestroyOnLoad(gameObject);
	}

	public void NewGame() {
		SceneManager.LoadScene("IntroNarration");
	}

	public void LoadGame() {
		load = true;
		playerData = SaveLoadManager.LoadPlayer();
		SceneManager.LoadScene("PersistentScene");
	}

	void OnEnable() {
		SceneManager.sceneLoaded += OnLevelFinishedLoaded;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnLevelFinishedLoaded;
	}

	void OnLevelFinishedLoaded(Scene scene, LoadSceneMode mode) {
		if(SceneManager.GetActiveScene().name == "PersistentScene") {
			player = GameObject.FindGameObjectWithTag("Player");
			Transform previewItemParent = player.transform.GetChild(0).Find("PreviewItemParent");
			SetPlayerStat(playerData);
			StartCoroutine(WaitDestroy(previewItemParent));
			if(load) {
				SceneManager.LoadScene(playerData.currentScene);
			} else {
				SceneManager.LoadScene("JoelHouseGame");
			}
		}
		// if(load) {
			// player = Instantiate(playerPrefab);
			// canvas = Instantiate(canvasPrefab);
			// SetPlayerStat(playerData);
			// audioManager = Instantiate(audioManagerPrefab);
			// cam = Instantiate(mainCameraPrefab);
			// load = false;
			// Debug.Log(string.Format("player: {0}, canvas: {1}, audioManager: {2}, cam: {3}, scene: {4}", 
			// 	player.name, canvas.name, 
			// 	audioManager.name, cam.name, 
			// 	SceneManager.GetActiveScene().name));
			// Destroy(player.transform.GetChild(0).GetChild(2).GetChild(0).gameObject);
			// DontDestroyOnLoad(player);
			// DontDestroyOnLoad(canvas);
			// DontDestroyOnLoad(audioManager);
			// DontDestroyOnLoad(cam);
		// }
	}

	void SetPlayerStat(PlayerData playerData) {
		PlayerPrefs.SetString("lastScene", "");
		player.GetComponent<Character>().inventoryModel.SetInventory(playerData.items);
		player.GetComponent<Character>().healthModel.SetHealth(playerData.HP);
		player.GetComponent<Character>().healthModel.SetMaxHealth(playerData.MaxHP);
		player.GetComponent<Character>().levelModel.SetCurrentExp(playerData.XP);
		player.GetComponent<Character>().levelModel.SetCurrentLevel(playerData.Level);
		player.GetComponent<Character>().questModel.SetMainQuest(playerData.mainQuest);
		player.GetComponent<Character>().questModel.SetSideQuest(playerData.sideQuests);
		player.transform.position = new Vector2(playerData.x, playerData.y);
	
	}

	public void SaveGame() {	
		Player playerScript = player.GetComponent<Player>();
		playerScript.Save();
		playerScript.CommitSave();
	}

	public void DeathSave() {
		Player playerScript = player.GetComponent<Player>();
		playerScript.Save();
		playerScript.ResetHealth();
		playerScript.CommitSave();
	}

	public string GetCurrentScene() {
		return playerData.currentScene;
	}

	void DestroyThem(Transform toDestroy) {
		int itemCount = toDestroy.childCount;
		while(itemCount > 0) {
			Destroy(toDestroy.GetChild(0));
			itemCount = toDestroy.childCount;
			Debug.Log(itemCount);
		}
	}

	IEnumerator WaitDestroy(Transform toDestroy) {
		yield return new WaitForSeconds(1.5f);
		DestroyThem(toDestroy);
	}
}
