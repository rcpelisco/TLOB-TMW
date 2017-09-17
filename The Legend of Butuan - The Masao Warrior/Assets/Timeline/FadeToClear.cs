using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToClear : MonoBehaviour {

	void OnEnable() {
		FadeManager.instance.Fade(false, 1.5f);
	}
}
