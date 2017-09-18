using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : CharacterBaseControl {

	public float floatTime = 1f;
	public float timeUntilNextAttack;
	public GameObject player;

	private Vector2 direction;
	private HandState handState;
	private float maxHeight = 3f;
	private float attackInterval;
	private bool isTargetLocked;
	private Vector3 target;
	private Vector3 previousPos;

	void Update() {
		UpdateRaise();
	}

	void UpdateRaise() {
		// while(transform.position != target + new Vector3(0, maxHeight)) {
		direction = transform.position - target + new Vector3(0, maxHeight);
		direction.Normalize();
		SetDirection(direction);
		Debug.Log(direction);
		// }
	
	}

	// IEnumerator Float() {
	// 	yield return new WaitForSeconds(2.5f);
	// 	Debug.Log("Float");
	// 	StartCoroutine(FindTarget());
	// }

	// IEnumerator FindTarget() {
	// 	yield return new WaitForSeconds(1.5f);
	// 	Debug.Log("FindTarget");
	// 	StartCoroutine(Drop());
	// }

	// IEnumerator Drop() {
	// 	yield return new WaitForSeconds(1.8f);
	// 	Debug.Log("Drop");
	// 	StartCoroutine(Rest());
	// }

	// IEnumerator Rest() {
	// 	yield return new WaitForSeconds(1.8f);
	// 	Debug.Log("Rest");
	// 	StartCoroutine(Raise());
	// }
}

public enum HandState {
	Raise,
	Float,
	FindTarget,
	Drop,
	Rest,
}
