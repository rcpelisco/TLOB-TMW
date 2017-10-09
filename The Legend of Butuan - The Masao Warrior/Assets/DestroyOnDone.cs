using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDone : MonoBehaviour {

	public GameObject[] DestroyGameObjects;

	void OnEnable() {
		foreach(GameObject o in DestroyGameObjects) {
			Destroy(o);
		}
	}
}
