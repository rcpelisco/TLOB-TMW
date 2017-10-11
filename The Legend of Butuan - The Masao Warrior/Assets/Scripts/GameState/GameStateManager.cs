using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {
	
	GameObject gameOverScreen;
	public Camera cam;
	public Canvas canvas;
	private CharacterHealthModel healthModel;

	
	void Awake() {
		gameOverScreen = GameObject.FindGameObjectWithTag("GameOverScreen");
		gameOverScreen.SetActive(false);
		healthModel = GetComponent<CharacterHealthModel>();
	}

	public void GameOver() {
		gameOverScreen.SetActive(true);
	}

	public void Restart() {
		StartCoroutine(ChangeScene());	
	}

	IEnumerator ChangeScene() {
		FadeManager.instance.Fade(true, 3f);
		yield return new WaitForSeconds(1.5f);
		Destroy(gameObject);
		Destroy(cam);
		Destroy(canvas);
		SceneManager.LoadScene("JoelHouse");
	}
}
