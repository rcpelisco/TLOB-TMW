using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : CharacterBaseControl {

	public float floatTime = 1f;
	public float timeUntilNextAttack;
	public Transform BagdokRestLeft;
	public Transform BagdokRestRight;

	private GameObject player;
	private Vector2 direction;
	private float maxHeight = 3f;
	private float attackInterval;
	private bool isTargetLocked;
	private bool isFloating;
	private Vector3 target;
	private Vector3 previousPos;

	void Awake() {
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Start() {
		StartCoroutine(Wait());
	}

	IEnumerator Wait() {
		yield return new WaitForSeconds(3f);
		StartCoroutine(Float());
	}

	IEnumerator Float() {
		yield return new WaitForSeconds(floatTime);
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
		yield return new WaitForSeconds(timeUntilNextAttack);
		if(GameObject.FindGameObjectWithTag("BagdokLeft") == gameObject) {
			transform.position = BagdokRestLeft.position;
		} else if(GameObject.FindGameObjectWithTag("BagdokRight") == gameObject) {
			transform.position = BagdokRestRight.position;
		}
		StartCoroutine(Float());
	}
}
