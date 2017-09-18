using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCControl : CharacterBaseControl {
	
	public bool canWalk;
	public float walkTime;
	public float waitTime;
	public bool isMoving;
	public bool canAttack;
	public Collider2D walkZone;

	private Vector2 direction;
	private Vector2 maxWalkPoint;
	private Vector2 minWalkPoint;
	private float walkCounter;
	private float waitCounter;
	private int walkDirection;
	private bool hasWalkZone;
	private bool isSpotted;
	
	void Start() {
		direction = Vector2.zero;
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
		if(canAttack) {
			UpdateAttack();
		}
	}

	void UpdateAttack() {
		CastLine();
	}

	void CastLine() {
		Debug.DrawLine(transform.position , (transform.position +  movementModel.GetFacingDirection() * 10), Color.red);
		isSpotted = Physics2D.Linecast(transform.position, (transform.position +  movementModel.GetFacingDirection() * 10), 1 << LayerMask.NameToLayer("Player"));
		if(isSpotted) {
			if(movementModel.CanAttack()) {
				OnAttackPressed();
			}
		}
	}

	void UpdateDirection() {
		if(canWalk) {
			if(isMoving) {
				walkCounter -= Time.deltaTime;
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
					StopWalking();
				}
				break;
			case 1:
				direction = new Vector2(1, 0);
				if(hasWalkZone && transform.position.x > maxWalkPoint.x) {
					StopWalking();
				}
				break;
			case 2:
				direction = new Vector2(0, -1);
				if(hasWalkZone && transform.position.y < minWalkPoint.y) {
					StopWalking();
				}
				break;
			case 3:
				direction = new Vector2(-1, 0);
				if(hasWalkZone && transform.position.x < minWalkPoint.x) {
					StopWalking();
				}
				break;
		}
	}

	void StopWalking() {
			isMoving = false;
			waitCounter = waitTime;
	}
}
