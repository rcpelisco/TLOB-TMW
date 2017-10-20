using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	void Start() {
		Debug.Log("GameOver");
		GameObject.FindObjectOfType<GameStateManager>().LoadGame();
	}
}
