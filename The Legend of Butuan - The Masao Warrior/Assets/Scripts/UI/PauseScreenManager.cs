using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreenManager : MonoBehaviour {

	GameObject[] screenElements;
	private int screenIndex;

	void Awake() {
		screenIndex = 0;
		screenElements = GameObject.FindGameObjectsWithTag("PauseScreenElement");
	}

	void Start() {
		foreach(GameObject elem in screenElements) {
			elem.SetActive(false);
		}
		screenElements[screenIndex].SetActive(true);
	}

	public void NextScreen() {
		screenElements[screenIndex].SetActive(false);
		screenIndex--;
		if(screenIndex < 0) {
			screenIndex = screenElements.Length - 1;
		}
		screenElements[screenIndex].SetActive(true);
	}

	public void PreviousScreen() {
		screenElements[screenIndex].SetActive(false);
		screenIndex++;
		if(screenIndex == screenElements.Length) {
			screenIndex = 0;
		}
		screenElements[screenIndex].SetActive(true);
	}
}
