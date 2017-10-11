using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {
	
	public GameObject mainCameraPrefab;
	public GameObject canvasPrefab;
	public GameObject playerPrefab;

	private Player playerScript;
	private GameObject player;
	private GameObject canvas;
	private GameObject cam;
	private static bool isExists;
	private AsyncOperation loadGameAsync;


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
		PlayerData playerData = SaveLoadManager.LoadPlayer();
		SceneManager.LoadScene(playerData.currentScene);
		StartCoroutine(LoadArea(playerData.currentScene));
		SetPlayerStat(playerData);
		cam = Instantiate(mainCameraPrefab);
		canvas = Instantiate(canvasPrefab);
	}

	IEnumerator LoadArea(string scene) {
		loadGameAsync = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Single);
		yield return null;
	}

	void SetPlayerStat(PlayerData playerData) {
		float playerX = playerData.x;
		float playerY = playerData.y;
		player = Instantiate(playerPrefab, new Vector3(playerX, playerY, 0), Quaternion.identity);
		player.GetComponent<Character>().healthModel.SetHealth(playerData.HP);
		player.GetComponent<Character>().healthModel.SetMaxHealth(playerData.MaxHP);
		player.GetComponent<Character>().levelModel.SetCurrentExp(playerData.XP);
		player.GetComponent<Character>().levelModel.SetCurrentLevel(playerData.Level);
	}

	public void SaveGame() {
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerScript.Save();
	}

}
