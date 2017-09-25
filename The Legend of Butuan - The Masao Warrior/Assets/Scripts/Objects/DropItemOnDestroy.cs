using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropItemOnDestroy : MonoBehaviour {
	
	public ItemType itemType;
	public int amount;

	[Range(0f, 1f)]
	public float probability;
	private static bool isQuitting;

	void OnEnable() {
		SceneManager.sceneLoaded += OnLevelFinishLoading;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= OnLevelFinishLoading;
	}

	void OnLevelFinishLoading(Scene scene, LoadSceneMode mode) {
		isQuitting = true;
	}

	void OnApplicationQuit() {
		isQuitting = true;
	}

	void OnDestroy() {
		if(!isQuitting) {
			OnLootDrop(); 
		}
	}

	void OnLootDrop() {
		float randomVal = Random.Range(0f, 1f);
		Debug.Log("randomVal: " + randomVal);
		if(randomVal > probability) {
			return;
		}

		ItemData data = Database.item.FindItem(itemType);

		if(data == null || data.prefab == null) {
			Debug.Log(data + " not found in database");
			return;
		}

		Instantiate(data.prefab, transform.position, Quaternion.identity);
	}
}
