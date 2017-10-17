using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemCounter : MonoBehaviour {

	public ItemType itemType;
	public string numberFormat;

	private CharacterInventoryModel inventoryModel;
	private Text text;

	void Start() {
		inventoryModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInventoryModel>();
		text = GetComponentInChildren<Text>();
	}
	
	void Update () {
		if(inventoryModel != null) {
			text.text = inventoryModel.GetItemCount(itemType).ToString(numberFormat);
		}
	}
}
