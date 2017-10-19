using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : CharacterBaseControl {
	
	public bool canWalk;
	public float walkTime;
	public float waitTime;
	public bool isMoving;
	public float attackWaitTime;
	public Collider2D walkZone;


	private Vector2 direction;
	private Vector2 maxWalkPoint;
	private Vector2 minWalkPoint;
	private float walkCounter;
	private float waitCounter;
	private int walkDirection;
	private bool hasWalkZone;
	private bool isSpotted;
	
	private float waitAttack;

	void Start() {
		direction = Vector2.zero;
		waitAttack = attackWaitTime;
		waitCounter = waitTime;
		walkCounter = walkTime;
		if(walkZone != null) {
			hasWalkZone = true;
			minWalkPoint = walkZone.bounds.min;
			maxWalkPoint = walkZone.bounds.max;
		}
	}

	void Update () {
		UpdateDirection();
		UpdateAttack();
	}

	void UpdateAttack() {
		if(waitAttack > 0f) {
			waitAttack -= Time.deltaTime;
		} else {
			DoShootPressed();
			waitAttack = attackWaitTime;
		}
	}

	void UpdateDirection() {
		if(canWalk) {
			if(isMoving) {
				walkCounter -= Time.deltaTime;
				if(transform.position.y > maxWalkPoint.y) {
					direction.y = -1;
				}
				if(transform.position.y < minWalkPoint.y) {
					direction.y = 1;
				}
				if(transform.position.x > maxWalkPoint.x) {
					direction.x = -1;
				}
				if(transform.position.x < minWalkPoint.x) {
					direction.x = 1;
				}
				if( walkCounter < 0) {
					StopWalking();
				}
			} else {
				direction = Vector2.zero;
				waitCounter -= Time.deltaTime;
				if(waitCounter < 0) {
					ChooseRandomDirection();
				}
			}
		}

		SetDirection(direction);
	}

	void ChooseRandomDirection() {
		walkDirection = Random.Range(0, 4);
		isMoving = true;
		walkCounter = walkTime;
		switch (walkDirection) {
			case 0:
				direction = new Vector2(0, 1);
				if(hasWalkZone && transform.position.y > maxWalkPoint.y) {
					direction = new Vector2(0, -1);
				}
				break;
			case 1:
				direction = new Vector2(1, 0);
				if(hasWalkZone && transform.position.x > maxWalkPoint.x) {
					direction = new Vector2(-1, 0);
				}
				break;
			case 2:
				direction = new Vector2(0, -1);
				if(hasWalkZone && transform.position.y < minWalkPoint.y) {
					direction = new Vector2(0, 1);
				}
				break;
			case 3:
				direction = new Vector2(-1, 0);
				if(hasWalkZone && transform.position.x < minWalkPoint.x) {
					direction = new Vector2(1, 0);
				}
				break;
		}
	}

	void StopWalking() {
			isMoving = false;
			waitCounter = waitTime;
	}
}
