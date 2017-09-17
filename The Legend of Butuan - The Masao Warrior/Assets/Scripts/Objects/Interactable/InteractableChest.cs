using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableChest : InteractableBase {

	Item item;
	Animator anim;
	bool isOpen = false;

	void Awake() {
		anim = GetComponentInChildren<Animator>();
		item = GetComponent<Item>();
	}

	public override void OnInteract(Character character) {
		if(isOpen) {
			return;
		}
		if(item != null) {
			item.Add(character);
			item.amount = 0;
		}
		anim.SetTrigger("openChest");
	}
}
