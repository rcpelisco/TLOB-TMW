using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTouchControl : CharacterBaseControl {

	Vector2 direction;

	void Start() {
		direction = Vector2.zero;
	}

	void Update() {
		SetDirection(direction);
	}

	public void UpdateAction() {
		OnActionPressed();
	}

	public void UpdateAttack() {
		OnAttackPressed();
	}

	public void WalkUp() {
		direction = new Vector2(0, 1);
	}
 
	public void WalkRight() {
		direction = new Vector2(1, 0);
	}
 
	public void WalkDown() {
		direction = new Vector2(0, -1);
	}
 
	public void WalkLeft() {
		direction = new Vector2(-1, 0);
	}
 
	public void ReleaseWalk() {
		direction = Vector2.zero;
	}

}
