using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour {

	public float floatTime = 1f;
	public float timeUntilNextAttack;
	public GameObject player;

	private float maxHeight = 3f;
	private float attackInterval;
	private bool isTargetLocked;
	private Vector2 target;
	private Vector2 previousPos;

	void Start() {
		attackInterval = timeUntilNextAttack;
	}

	public void UpdateAttack() {
		attackInterval = Mathf.MoveTowards(attackInterval, 0, Time.deltaTime);
		if(attackInterval <= 0) {
			RaiseHand();
		}
	}

	void Update() {
		UpdateAttack();
	}

	void LockTarget() {
		if(!isTargetLocked) {
			target = player.transform.position;
			isTargetLocked = true;
		} else {
			return;
		}
	}

	void FindTarget() {
		target = player.transform.position;
	}

	void DroppedPosition() {
		previousPos = transform.position; 
	}

	void RaiseHand() {
		transform.position = Vector2.MoveTowards(transform.position, target + new Vector2(0, maxHeight), Time.deltaTime * 10);
	}

	void DropHand() {

	}
}
