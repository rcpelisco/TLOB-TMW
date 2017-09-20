using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemCounter : MonoBehaviour {

	public CharacterInventoryModel inventoryModel;
	public ItemType itemType;
	public string numberFormat;

	private Text text;

	void Awake() {
		inventoryModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInventoryModel>();
		text = GetComponentInChildren<Text>();
	}
	
	void Update () {
		if(inventoryModel != null) {
			text.text = inventoryModel.GetItemCount(itemType).ToString(numberFormat);
		}
	}
}
