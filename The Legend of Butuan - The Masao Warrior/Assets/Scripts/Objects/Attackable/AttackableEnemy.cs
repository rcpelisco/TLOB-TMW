﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableEnemy : AttackableBase {

	public float maxHealth;
	public GameObject destroyObjectOnDeath;
	public CharacterMovementModel movementModel;
	public float hitPushStrength;
	public float hitPushDuration;
	public float destroyDelay;
	public GameObject deathFX;
	public float deathFXDelay;
	public int expToGive;
	public EnemyType enemyType;
	public AudioSource enemyDeath;

	private float health;
	private CharacterLevelModel playerLevelModel;
	private CharacterQuestModel questModel;

	void Start() {
  		playerLevelModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterLevelModel>();
		questModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterQuestModel>();
		health = maxHealth;
	}	

	public void Kill() {
		health = 0;
		CheckHealth();
	}

	public void CheckHealth() {
		if(health <= 0) {
			if(playerLevelModel != null) {
				playerLevelModel.AddExp(expToGive);
			}
			if(questModel != null) {
				questModel.AddKilledEnemy(enemyType);
			}
			Destroy(destroyObjectOnDeath, destroyDelay);
			if(deathFX != null) {
				StartCoroutine(CreateDeathFXDelay(deathFXDelay));
			}
			enemyDeath.Play();
		}
	}

	public override void OnHit(Collider2D hitCollider, ItemType item) {
		float damage = 20;
		health -= damage;
		UIDamageNumbers.Instance.ShowDamageNumber(damage, transform.position);
		if(movementModel != null) {
			Vector2 pushDirection = transform.position - hitCollider.gameObject.transform.position;
			pushDirection = pushDirection.normalized * hitPushStrength;
			movementModel.PushCharacter(pushDirection, hitPushDuration);
		}
		CheckHealth();
	}

	public float GetHealth() {
		return health;
	}

	IEnumerator CreateDeathFXDelay(float delay) {
		yield return new WaitForSeconds(delay);
		Instantiate(deathFX, transform.position, Quaternion.identity);
	}
}