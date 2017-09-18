using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandScript : MonoBehaviour {

	public float floatTime = 1f;
	public float timeUntilNextAttack;
	public GameObject player;

	private HandState handState;
	private float maxHeight = 3f;
	private float attackInterval;
	private bool isTargetLocked;
	private Vector2 target;
	private Vector2 previousPos;

	void Start() {
		StartCoroutine(Raise());
	}

	IEnumerator Raise() {
		yield return new WaitForSeconds(2f);
		Debug.Log("Raise");
		StartCoroutine(Float());
	}

	IEnumerator Float() {
		yield return new WaitForSeconds(2.5f);
		Debug.Log("Float");
		StartCoroutine(FindTarget());
	}

	IEnumerator FindTarget() {
		yield return new WaitForSeconds(1.5f);
		Debug.Log("FindTarget");
		StartCoroutine(Drop());
	}

	IEnumerator Drop() {
		yield return new WaitForSeconds(1.8f);
		Debug.Log("Drop");
		StartCoroutine(Rest());
	}

	IEnumerator Rest() {
		yield return new WaitForSeconds(1.8f);
		Debug.Log("Rest");
		StartCoroutine(Raise());
	}
}

public enum HandState {
	Raise,
	Float,
	FindTarget,
	Drop,
	Rest,
}
