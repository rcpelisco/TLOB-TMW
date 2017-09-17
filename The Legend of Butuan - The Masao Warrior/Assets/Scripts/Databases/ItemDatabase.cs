using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : ScriptableObject {
	
	public List<ItemData> data;
	
	public ItemData FindItem(ItemType itemType) {
		for(int i = 0; i < data.Count; i++) {
			if(data[i].type == itemType) {
				return data[i];
			}
		}
		return null;
	}
}

[System.Serializable]
public class ItemData {
	public enum PickupAnimation {
		None,
		OneHanded,
		TwoHanded
	}
	public enum EquipPosition {
		NotEquipable,
		SwordHand,
		ShieldHand
	}
	public ItemType type;
	public GameObject prefab;
	public EquipPosition isEquipable;
	public PickupAnimation animation;
}