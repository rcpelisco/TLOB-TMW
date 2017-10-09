using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : CharacterBaseControl {

	public float floatTime = 1f;
	public float timeUntilNextAttack;
	public GameObject player;
	public Transform BagdokRestLeft;
	public Transform BagdokRestRight;

	private Vector2 direction;
	private HandState handState;
	private float maxHeight = 3f;
	private float attackInterval;
	private bool isTargetLocked;
	private bool isFloating;
	private Vector3 target;
	private Vector3 previousPos;

	void Update() {
		if(!isFloating) {
			isFloating = true;
			StartCoroutine(Float());
		}
	}

	IEnumerator Float() {
		yield return new WaitForSeconds(2.5f);
		transform.position = transform.position + (new Vector3(0, maxHeight, 0));
		StartCoroutine(FindTarget());
	}

	IEnumerator FindTarget() {
		yield return new WaitForSeconds(1.5f);
		float x = player.transform.position.x;
		float y = player.transform.position.y;
		transform.position = (new Vector3(x, y + maxHeight, 0));
		StartCoroutine(Drop());
	}

	IEnumerator Drop() {
		yield return new WaitForSeconds(1.8f);
		transform.position += new Vector3(0, -maxHeight - .5f, 0);
		StartCoroutine(Rest());
	}

	IEnumerator Rest() {
		yield return new WaitForSeconds(1.8f);
		transform.position = BagdokRestLeft.position;
		StartCoroutine(Float());
	}
}

public enum HandState {
	Raise,
	Float,
	FindTarget,
	Drop,
	Rest,
}
