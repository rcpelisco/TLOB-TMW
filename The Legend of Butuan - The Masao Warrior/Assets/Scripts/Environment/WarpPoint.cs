using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WarpPoint : MonoBehaviour {

	public string nextScene;
	public string previousScene;
	public int previousIndex;
	public int nextIndex;

	private float fadeTime = .25f;
	private string lastScene;
	private int lastIndex;

	void Awake() {
		lastScene = PlayerPrefs.GetString("lastScene");
		lastIndex = PlayerPrefs.GetInt("lastIndex");
	}

	void Start() {
		if(lastScene == nextScene && lastIndex == nextIndex) {
			if(FindObjectOfType<Player>() != null) {
				FindObjectOfType<Player>().transform.position = transform.position;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.tag == "Player") {
			lastIndex = previousIndex;
			lastScene = SceneManager.GetActiveScene().name;
			PlayerPrefs.SetInt("lastIndex", lastIndex);
			PlayerPrefs.SetString("lastScene", lastScene);
			FadeManager.instance.Fade(true, fadeTime);
			StartCoroutine(LoadSceneCoroutine(nextScene));
		}
	}

	IEnumerator LoadSceneCoroutine(string scene) {
		yield return new WaitForSeconds(.5f);
		SceneManager.LoadScene(nextScene);
	}
}
