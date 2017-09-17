using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardTrigger : MonoBehaviour {

	RangeWizardControl control;

	void Awake() {
		control = GetComponentInParent<RangeWizardControl>();
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.tag == "Player") {
			control.SetCharacterInRange(collider.gameObject);
		}
	}
}
