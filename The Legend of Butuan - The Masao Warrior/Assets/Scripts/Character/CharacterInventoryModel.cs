using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInventoryModel : MonoBehaviour {

	public ItemType[] item;
	public AudioSource collectGold, getSword, smallItem;

	private CharacterMovementModel movementModel;
	private InventoryUI inventoryUI;
	
	Dictionary<ItemType, int> items = new Dictionary<ItemType, int>();
	
	void Awake() {
		movementModel = GetComponent<CharacterMovementModel>();
	}

	void Start() {
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
			if(itemType != ItemType.Gold) {
				FindObjectOfType<InventoryUI>().AddItem(itemType);
			}else {
				collectGold.Play();
			}
			if(itemData != null) {
				if(itemData.animation != ItemData.PickupAnimation.None) {
					movementModel.ShowItemPickup(itemType);
				}
				if(itemData.isEquipable == ItemData.EquipPosition.SwordHand) {
					getSword.Play();
					movementModel.EquipWeapon(itemType);
				} else if (itemData.isEquipable == ItemData.EquipPosition.ShieldHand) {
					movementModel.EquipShield(itemType);
				} else if (itemData.isEquipable == ItemData.EquipPosition.NotEquipable && itemType != ItemType.Gold) {
					smallItem.Play();
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

	public Dictionary<ItemType, int> GetInventory() {
		return items;
	}

	public void SetInventory(Dictionary<ItemType, int> items) {
		foreach(KeyValuePair<ItemType, int> _item in items) {
			AddItem(_item.Key, _item.Value);
		}
	}
}
