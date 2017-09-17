using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

	public ItemType item;
	public int amount;
	
	private bool isDone;

	public void Add(Character character) {
		if(!isDone) {
			isDone = true;
			character.inventoryModel.AddItem(item, amount);
			Debug.Log(amount + " " + item + " added!");
		}
	}

	public bool IsDone() {
		return isDone;
	}
}
