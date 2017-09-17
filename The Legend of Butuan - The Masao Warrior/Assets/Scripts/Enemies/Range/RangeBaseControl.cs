using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeBaseControl : MonoBehaviour {

	protected WizardModel movementModel;
	protected WizardView movementView;

	void Awake() {
		movementModel = GetComponent<WizardModel>();
		movementView = GetComponent<WizardView>();
	}

	protected void SetDirection(Vector2 direction) {
		if(movementModel == null) {
			return;
		}
		movementModel.SetDirection(direction);
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
}
