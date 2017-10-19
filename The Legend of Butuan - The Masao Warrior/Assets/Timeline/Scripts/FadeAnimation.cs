using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimation : MonoBehaviour {

	void OnEnable() {
		if(!AnimationFadeManager.instance) {
			AnimationFadeManager.instance.Fade(false, 1.5f);
		}
	}
	void OnDisable() {
		if(!AnimationFadeManager.instance) {
			AnimationFadeManager.instance.Fade(true, 1.5f);
		}
	}

}
