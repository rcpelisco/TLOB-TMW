using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacterCollision : MonoBehaviour {

	private CharacterSlimeControl control;

	void Awake() {
		control = GetComponentInParent<CharacterSlimeControl>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.CompareTag("Player")) {
			control.OnHitCharacter(collider.gameObject.GetComponent<Character>());
		}
	}
}
