using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeAnimation : MonoBehaviour {

	void OnEnable() {
		FadeManager.instance.Fade(false, 1.5f);
		Debug.Log("Fade");
	}
	void OnDisable() {
		FadeManager.instance.Fade(true, 1.5f);
		Debug.Log("Fade");
	}

}
