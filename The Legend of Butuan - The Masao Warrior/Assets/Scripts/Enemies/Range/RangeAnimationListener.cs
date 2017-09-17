using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAnimationListener : MonoBehaviour {

	public WizardModel movementModel;
	public WizardView movementView;

	public void OnAttackStarted() {
		if(movementModel != null) {
			movementModel.OnAttackStarted();
		}
	}

	public void OnAttackFinished() {
		if(movementModel != null) {
			movementModel.OnAttackFinished();
		}
	}
}
