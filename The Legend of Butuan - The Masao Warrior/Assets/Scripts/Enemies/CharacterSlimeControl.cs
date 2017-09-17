using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSlimeControl : CharacterBaseControl {

	public float pushStrength;
	public float pushTime;
	public AttackableEnemy attackableEnemy;
	public float AttackDamage;

	private GameObject characterInRange;

	void Update() {
		UpdateDirection();
	}

	void UpdateDirection() {
		Vector2 direction = Vector2.zero;
		if(characterInRange != null) {
			direction = characterInRange.transform.position - transform.position;
			direction.Normalize();
		}
		if(attackableEnemy != null && attackableEnemy.GetHealth() <= 0) {
			direction =  Vector2.zero;
		}
		SetDirection(direction);
	}

	public void SetCharacterInRange(GameObject characterInRange) {
		this.characterInRange = characterInRange;
	}

	public void OnHitCharacter(Character character) {
		Vector2 direction = character.transform.position - transform.position;	
		direction.Normalize();
		characterInRange = null;
		character.movementModel.PushCharacter(direction * pushStrength, pushTime);
		character.healthModel.DealDamage(AttackDamage);
	}
}
