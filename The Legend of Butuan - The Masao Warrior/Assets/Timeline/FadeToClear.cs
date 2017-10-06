using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToClear : MonoBehaviour {

	void OnEnable() {
		AnimationFadeManager.instance.Fade(false, 1.5f);
	}
}
