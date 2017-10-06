using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryModel : MonoBehaviour {

	public ItemType[] item;

	private CharacterMovementModel movementModel;
	private InventoryUI inventoryUI;
	
	Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();
	
	void Awake() {
		movementModel = GetComponent<CharacterMovementModel>();
		inventoryUI = FindObjectOfType<InventoryUI>();
	}

	public int GetItemCount(ItemType itemType) {
		if(items.ContainsKey(itemType)) {
			return items[itemType];
		}
		return 0;
	}

	public void AddItem(ItemType itemType) {
		AddItem(itemType, 1);
	}

	public void AddItem(ItemType itemType, int amount) {
		if(items.ContainsKey(itemType)) {
			items[itemType] += amount;
		} else {
			items.Add(itemType, amount);
		}
		if(amount > 0) {
			ItemData itemData = Database.item.FindItem(itemType);
			if(inventoryUI != null && itemType != ItemType.Gold) {
				inventoryUI.AddItem(itemType);
			}
			if(itemData != null) {
				if(itemData.animation != ItemData.PickupAnimation.None) {
					movementModel.ShowItemPickup(itemType);
				}
				if(itemData.isEquipable == ItemData.EquipPosition.SwordHand) {
					movementModel.EquipWeapon(itemType);
				} else if (itemData.isEquipable == ItemData.EquipPosition.ShieldHand){
					movementModel.EquipShield(itemType);
				}
			}
		}
	}

	IEnumerator AddSingleCoin(int amount) {
		yield return new WaitForSeconds(0.05f);
	}

	public bool HasItem(ItemType itemType) {
		if(items.ContainsKey(itemType)) {
			return true;
		}
		return false;
	}
}
