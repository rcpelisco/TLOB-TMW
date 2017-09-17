using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleItem : MonoBehaviour {

	private Item item;

	void Awake() {
		item = GetComponent<Item>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		Character character = collider.GetComponent<Character>();
		if(character != null) {
			item.Add(character);
			Destroy(gameObject);
		}
	}
}
