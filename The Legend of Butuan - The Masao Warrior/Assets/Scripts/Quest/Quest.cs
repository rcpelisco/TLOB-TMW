using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour {

	public QuestData quest;
	
	private bool isDone;
	private Image avatar;

	void Awake() {
		avatar = GetComponentInChildren<Image>();
		quest.giver = avatar.sprite;
	}

	public void Add(Character character) {
		if(!isDone) {
			isDone = true;
			character.questModel.CheckProgress(quest);
		}
	}

	public bool IsDone() {
		return isDone;
	}
}
