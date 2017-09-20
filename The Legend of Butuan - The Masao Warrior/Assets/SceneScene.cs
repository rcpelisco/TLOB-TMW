using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScene : MonoBehaviour {

	public string scene;

	public void NextScene(string scene) {
		StartCoroutine(GoToNextScene(scene));
	}

	IEnumerator GoToNextScene(string scene) {
		FadeManager.instance.Fade(true, 1.5f);
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene(scene);
	}
}
