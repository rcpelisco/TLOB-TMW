using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBaseControl : MonoBehaviour {

	protected CharacterMovementModel movementModel;
	protected CharacterMovementView movementView;
	protected CharacterInteractionModel interactionModel;

	void Awake() {
		movementModel = GetComponent<CharacterMovementModel>();
		movementView = GetComponent<CharacterMovementView>();
		interactionModel = GetComponent<CharacterInteractionModel>();
	}

	protected void SetDirection(Vector2 direction) {
		if(movementModel == null) {
			return;
		}
		movementModel.SetDirection(direction);
	}

	protected void OnActionPressed() {
		if(interactionModel == null) {
			return;
		}	
		interactionModel.OnInteract();
	}

	protected void OnAttackPressed() {
		if(movementModel == null) {
			return;
		}
		if(!movementModel.CanAttack()) {
			return;
		}
		movementModel.DoAttack();
		movementView.DoAttack();
	}

	protected void DoShootPressed() {
		if(movementModel == null) {
			return;
		}
		movementModel.DoShoot();
	}
}
