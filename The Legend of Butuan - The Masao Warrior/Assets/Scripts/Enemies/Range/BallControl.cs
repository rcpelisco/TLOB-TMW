﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : CharacterBaseControl {

	public float pushStrength;
	public float pushTime;
	public AttackableEnemy attackableEnemy;
	public float AttackDamage;

	private GameObject characterInRange;
	private Transform characterLastPosition;

	void Update() {
		UpdateDirection();
	} 

	void UpdateDirection() {
		Vector2 direction = Vector2.zero;
		if(characterLastPosition != null) {
			Debug.Log(characterLastPosition.position);
			direction = characterLastPosition.position - transform.position;
			direction.Normalize();
		}
		if(attackableEnemy != null && attackableEnemy.GetHealth() <= 0) {
			direction =  Vector2.zero;
		}
		SetDirection(direction);
	} 

	public void SetCharacterInRange(GameObject characterInRange) {
		this.characterLastPosition = characterInRange.transform;
		// this.characterInRange = characterInRange;
		Debug.Log(characterLastPosition.position);
	}

	public void OnHitCharacter(Character character) {
		Vector2 direction = character.transform.position - transform.position;	
		direction.Normalize();
		characterInRange = null;
		character.movementModel.PushCharacter(direction * pushStrength, pushTime);
		character.healthModel.DealDamage(AttackDamage);
		attackableEnemy.Kill();
	}
}
