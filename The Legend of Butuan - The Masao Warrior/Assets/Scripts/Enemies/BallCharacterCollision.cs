using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCharacterCollision : MonoBehaviour {

	private BallControl control;

	void Awake() {
		control = GetComponentInParent<BallControl>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.CompareTag("Player")) {
			control.OnHitCharacter(collider.gameObject.GetComponent<Character>());
		}
	}


}
