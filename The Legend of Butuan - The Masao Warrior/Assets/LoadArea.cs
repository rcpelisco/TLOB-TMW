using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArea : MonoBehaviour {
	void Start () {
		GameObject.FindObjectOfType<GameStateManager>().LoadGame();
	}
}
