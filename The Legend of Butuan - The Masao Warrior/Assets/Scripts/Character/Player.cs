using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

	private static bool isPlayerExists;
	private Character playerStats;
	private float uniqueID;

	void Awake() {
		playerStats = GetComponent<Character>();
		uniqueID = transform.position.x + transform.position.y;
		if(!isPlayerExists) {
			isPlayerExists = true;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}

	public float HP;
	public float MaxHP;
	public int Level;
	public int XP;
	public string currentScene;
	public float x;
	public float y;

	public void Save() {
		HP = playerStats.healthModel.GetHealth();
		MaxHP = playerStats.healthModel.GetMaxHealth();
		Level = playerStats.levelModel.GetCurrentLevel();
		XP = playerStats.levelModel.GetCurrentExp();
		currentScene = SceneManager.GetActiveScene().name;
		x = transform.position.x;
		y = transform.position.y;
		SaveLoadManager.SavePlayer(this);
	}

	public void Load() {
		PlayerData playerData = SaveLoadManager.LoadPlayer();
		playerStats.healthModel.SetMaxHealth(playerData.MaxHP);
		playerStats.healthModel.SetHealth(playerData.HP);
		playerStats.levelModel.SetCurrentExp(playerData.XP);
		playerStats.levelModel.SetCurrentLevel(playerData.Level);
		SceneManager.LoadScene(playerData.currentScene);
	}
}
