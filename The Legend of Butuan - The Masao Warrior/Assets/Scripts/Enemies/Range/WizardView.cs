using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardView : MonoBehaviour {

	public Animator animator;
	private WizardModel movementModel;

	void Awake() {
		if(animator == null) {
			Debug.Log("Animator is not added!");
			enabled = false;
		}
		movementModel = GetComponent<WizardModel>();
	}

	void Update() {
		UpdateDirection();
	}

	void UpdateDirection() {
		Vector3 direction = movementModel.GetDirection();
		if(direction != Vector3.zero) {
			animator.SetFloat("x", direction.x);
			animator.SetFloat("y", direction.y);
		}
		animator.SetBool("isWalking", movementModel.IsMoving());
	}

	public void DoAttack() {
		animator.SetTrigger("doAttack");
	}

	public void OnAttackStarted() {
		
	}

	public void OnAttackFinished() {

	}
}
