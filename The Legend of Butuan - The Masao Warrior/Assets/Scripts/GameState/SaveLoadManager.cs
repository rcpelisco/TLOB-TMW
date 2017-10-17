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
		bf.Serialize(fs, playerData);
		fs.Close();
	}

	public static PlayerData LoadPlayer() {
		if(File.Exists(Application.persistentDataPath + "/player.lob")) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fs = new FileStream(Application.persistentDataPath + "/player.lob", FileMode.Open);
			PlayerData playerData = bf.Deserialize(fs) as PlayerData;
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
	// public QuestData mainQuest;
	// public List<QuestData> sideQuests;

	public PlayerData(Player player) {
		HP = player.HP;
		MaxHP = player.MaxHP;
		XP = player.XP;
		Level = player.Level;
		currentScene = player.currentScene;
		x = player.x;
		y = player.y;
		items = player.items;
		// mainQuest = player.mainQuest;
		// sideQuests = player.sideQuests;
	}
}