using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimation : MonoBehaviour {

	Animator anim;
	public float initFacingDirX;
	public float initFacingDirY;
	void Awake () {
		anim = GetComponentInChildren<Animator>();
		if(anim != null) {
			anim.SetFloat("x", initFacingDirX);
			anim.SetFloat("y", initFacingDirY);
		}
	}

	public void DoWalkAnim(float x, float y) {
		if(anim != null) {
			anim.SetBool("isWalking", true);
			anim.SetFloat("x", x);
			anim.SetFloat("y", y);
		}
	}

	public void StopWalkAnim() {
		if(anim != null) {
			anim.SetBool("isWalking", false);
		}
	}
}
