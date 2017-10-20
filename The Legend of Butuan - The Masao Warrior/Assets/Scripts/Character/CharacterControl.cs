using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : CharacterBaseControl {

	void Start() {
		SetDirection( new Vector2( 0, -1 ) );
	}

	void Update() {
		UpdateDirection();
		UpdateAction();
		UpdateAttack();
	}

	void UpdateAttack() {
		if(Input.GetKeyDown(KeyCode.Space)) {
			OnAttackPressed();
		}
	}

	void UpdateAction() {
		if(Input.GetKeyDown(KeyCode.E)) {
			OnActionPressed();
		}
	}

	void UpdateDirection() {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		SetDirection(new Vector2(x, y));
	}
}
