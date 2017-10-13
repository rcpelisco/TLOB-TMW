using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoadManager {

	public static void SavePlayer(Player player) {
		BinaryFormatter bf = new BinaryFormatter();
		FileStream fs = new FileStream(Application.persistentDataPath + "/player.lob", FileMode.Create);
		PlayerData playerData = new PlayerData(player);
		Debug.Log("=== SAVE ===");
		Debug.Log(playerData.HP);
		Debug.Log(playerData.MaxHP);
		Debug.Log(playerData.XP);
		Debug.Log(playerData.Level);
		Debug.Log(playerData.currentScene);
		Debug.Log(playerData.x);
		Debug.Log(playerData.y);
		Debug.Log(playerData.items.Count);
		bf.Serialize(fs, playerData);
		fs.Close();
	}

	public static PlayerData LoadPlayer() {
		if(File.Exists(Application.persistentDataPath + "/player.lob")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fs = new FileStream(Application.persistentDataPath + "/player.lob", FileMode.Open);
			PlayerData playerData = bf.Deserialize(fs) as PlayerData;
			Debug.Log("=== LOAD ===");
			Debug.Log(playerData.HP);
			Debug.Log(playerData.MaxHP);
			Debug.Log(playerData.XP);
			Debug.Log(playerData.Level);
			Debug.Log(playerData.currentScene);
			Debug.Log(playerData.x);
			Debug.Log(playerData.y);
			Debug.Log(playerData.items.Keys);
			fs.Close();
			return playerData;
		}
		return null;
	}
}

[Serializable]
public class PlayerData {

	public float HP;
	public float MaxHP;
	public int XP;
	public int Level;
	public string currentScene;
	public float x;
	public float y;
	public Dictionary<ItemType, int> items;

	public PlayerData(Player player) {
		HP = player.HP;
		MaxHP = player.MaxHP;
		XP = player.XP;
		Level = player.Level;
		currentScene = player.currentScene;
		x = player.x;
		y = player.y;
		items = player.items;
	}
}