using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private static bool isPlayerExists;

	private CharacterInventoryModel inventoryModel;



	void Awake() {
		if(!isPlayerExists) {
			isPlayerExists = true;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
		inventoryModel = GetComponent<CharacterInventoryModel>();
	}

	public bool CheckBook() {
		if(inventoryModel.HasItem(ItemType.Book)) {
			return true;
		}
		return false;
 	}
}
