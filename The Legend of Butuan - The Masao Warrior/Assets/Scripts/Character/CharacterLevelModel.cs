using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevelModel : MonoBehaviour {

	public int currentLevel;
	[SerializeField]
	private int currentExp;
	private int[] requiredExp = {
		0,10,20,50,75,100,200,250,325,450,700,875,1000
	};
	int temp = 0;

	void Awake() {
		currentLevel = 1;
	}
	
	public int GetCurrentLevel() {
		return currentLevel;
	}

	public int GetCurrentExp() {
		return currentExp;
	}

	public void SetCurrentLevel(int newCurrentLevel) {
		currentLevel = newCurrentLevel;
	}

	public void SetCurrentExp(int newCurrentExp) {
		currentExp = newCurrentExp;
	}

	public int GetRequiredExp() {
		return requiredExp[currentLevel];
	}

	public float GetExpPercentage() {
		return currentExp / requiredExp[currentLevel];
	}

	public void AddExp(int newExp) {
		StartCoroutine(AddSingleXP(newExp));
	}

	IEnumerator AddSingleXP(int exp) {
		while(exp != 0) {
			yield return new WaitForSeconds(0.05f);
			currentExp++;
			exp--;
		}
	}

	void Update () {
		if(currentExp >= requiredExp[currentLevel]) {
			temp = currentExp - requiredExp[currentLevel];
			currentLevel++;
			currentExp = temp;
		}
	}
}
