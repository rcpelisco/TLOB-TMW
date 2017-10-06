using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimation : MonoBehaviour {

	void OnEnable() {
		AnimationFadeManager.instance.Fade(false, 1.5f);
		Debug.Log("Fade");
	}
	void OnDisable() {
		AnimationFadeManager.instance.Fade(true, 1.5f);
		Debug.Log("Fade");
	}

}
