using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevelModel : MonoBehaviour {

	public int currentLevel;
	[SerializeField]
	private float currentExp;
	private float[] requiredExp = {
		0,10,20,50,75,100,200,250,325,450,700,875,1000
	};
	[SerializeField]
	float temp = 0f;

	void Awake() {
		currentLevel = 1;
	}
	
	public int GetCurrentLevel() {
		return currentLevel;
	}

	public float GetCurrentExp() {
		return currentExp;
	}

	public float GetRequiredExp() {
		return requiredExp[currentLevel];
	}

	public float GetExpPercentage() {
		return currentExp / requiredExp[currentLevel];
	}

	public void AddExp(float newExp) {
		StartCoroutine(AddSingleXP(newExp));
	}

	IEnumerator AddSingleXP(float exp) {
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
