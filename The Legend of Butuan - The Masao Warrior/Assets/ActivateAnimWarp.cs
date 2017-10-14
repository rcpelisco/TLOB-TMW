using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class ActivateAnimWarp : MonoBehaviour {

	public PlayableDirector playable;

	void Awake() {
		if(playable == null) {
			return;
		}
		// if(GetComponent<WarpPoint>().previousScene == PlayerPrefs.GetString()) {
		// 	playable.Play();
		// }
	}
}
