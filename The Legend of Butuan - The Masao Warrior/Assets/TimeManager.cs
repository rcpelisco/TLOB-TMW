using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Time.timeScale = 2f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDisable() {
		Time.timeScale = 1;
	}
}
