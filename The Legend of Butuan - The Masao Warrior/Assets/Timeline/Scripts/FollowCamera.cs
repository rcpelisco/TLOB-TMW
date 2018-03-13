using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {

	// Use this for initialization
	void OnEnable () {
		FindObjectOfType<CameraController>().enabled = true;
		GameObject.Find("Bagdok anim").SetActive(true);
	}
	
}
