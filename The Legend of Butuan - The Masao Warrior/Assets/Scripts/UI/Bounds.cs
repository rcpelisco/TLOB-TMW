using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour {

	private BoxCollider2D bounds;
	private CameraController cam;

	void Awake() {
		bounds = GetComponent<BoxCollider2D>();
		cam = FindObjectOfType<CameraController>();
		if(bounds != null && cam != null) {
			cam.SetBoundBox(bounds);

		}
	}
}
