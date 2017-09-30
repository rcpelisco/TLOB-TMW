using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private static bool isPlayerExists;

	void Awake() {
		if(!isPlayerExists) {
			isPlayerExists = true;
			DontDestroyOnLoad(gameObject);
		} else {
			Destroy(gameObject);
		}
	}
}
