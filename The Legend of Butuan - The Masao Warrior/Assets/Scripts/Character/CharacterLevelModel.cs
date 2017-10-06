using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevelModel : MonoBehaviour {

	public int currentLevel;
	private int currentExp;
	private int[] requiredExp;

	void Awake() {
		currentLevel = 1;
	}
	
	public int GetCurrentExp() {
		return currentExp;
	}

	public int GetRequiredExp() {
		return requiredExp[currentExp];
	}

	void Update () {

	}
}
