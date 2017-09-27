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
		Debug.Log(quest.giver, quest.giver);
	}

	public void Add(Character character) {
		if(!isDone) {
			isDone = true;
			character.questModel.AddQuest(quest);
		}
	}

	public bool IsDone() {
		return isDone;
	}
}
