using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour {

	public const int numItemSlots = 16;
	public Image[] itemImages = new Image[numItemSlots];
	public ItemType[] items = new ItemType[numItemSlots];

	public void AddItem(ItemType itemType) {
		Debug.Log("InventoryUI.AddItem");
		Sprite itemToAdd = Database.item.FindItem(itemType).prefab.GetComponentInChildren<SpriteRenderer>().sprite;
		for(int i = 0; i < items.Length; i++){
			if(items[i] == ItemType.None) {
				items[i] = itemType;
				itemImages[i].sprite = itemToAdd;
				itemImages[i].enabled = true;
				return;
			}
		}
	}

	public void RemoveItem(ItemType itemType) {
		for(int i = 0; i < items.Length; i++){
			// ItemData itemToAdd = Database.item.FindItem(itemType);
			if(items[i] == itemType) {
				items[i] = ItemType.None;
				itemImages[i].sprite = null;
				itemImages[i].enabled = false;
				return;
			}
		}
	}
}
