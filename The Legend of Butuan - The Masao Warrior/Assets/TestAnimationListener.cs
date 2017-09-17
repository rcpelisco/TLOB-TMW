using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimationListener : MonoBehaviour {

	bool isFrozen;
	Animator animator;


	void Start () {
		animator = GetComponent<Animator>();
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)) {
			Pickup();
		}
		UpdateAnimation();
	}

	void Pickup() {
		if(!isFrozen) {
			isFrozen = true;
		}
	}

	void UpdateAnimation() {
		animator.SetBool("pickup", isFrozen);
	}

}
