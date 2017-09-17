using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityTrigger : MonoBehaviour {

	CharacterSlimeControl control;

	void Awake() {
		control = GetComponentInParent<CharacterSlimeControl>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.tag == "Player") {
			control.SetCharacterInRange(collider.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D collider) {
		if(collider.tag == "Player") {
			control.SetCharacterInRange(null);
		}
	}
}
