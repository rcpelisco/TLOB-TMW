using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterLevelModel : MonoBehaviour {

	public int currentLevel;
	public AudioSource playerLevelUp;

	[SerializeField]
	private int currentExp;
	private int[] requiredExp = {
		0, 50, 100, 175, 275, 400, 550, 
		725, 925, 450, 700, 875, 1000
	};
	private CharacterHealthModel healthModel;
	int temp = 0;
	
	void Awake() {
		currentLevel = 1;
		healthModel = GetComponent<CharacterHealthModel>();
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
		return (float)currentExp / (float)requiredExp[currentLevel];
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
			healthModel.SetMaxHealth(LevelUpHealth());
			healthModel.ResetHealth();
			playerLevelUp.Play();
			currentExp = temp;
		}
	}

	float LevelUpHealth() {
		float currentMaxHP = healthModel.GetMaxHealth();
		float newMaxHP = currentMaxHP + currentMaxHP * (currentLevel / 32f);
		return newMaxHP;
	}
}
