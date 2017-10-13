using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchToStart : MonoBehaviour {

	public void TouchScreen() {
		if(gameObject.activeSelf) {
			StartCoroutine(NextScene());

		}
	}

	IEnumerator NextScene() {
		FadeManager.instance.Fade(true, 1f);
		yield return new WaitForSeconds(1.5f);
		SceneManager.LoadScene("MainMenu");
	}
}
