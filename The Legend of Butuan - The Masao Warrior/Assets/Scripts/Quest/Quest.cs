using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour {

	public QuestData quest;
	
	private bool isDone;

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
