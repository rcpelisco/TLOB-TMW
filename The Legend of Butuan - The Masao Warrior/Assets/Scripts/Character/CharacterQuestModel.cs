using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterQuestModel : MonoBehaviour {

	private QuestData currentQuest;

	public void AddQuest(QuestData quest) {
		if(currentQuest != null) {
			Debug.Log("Finish Current Quest first!");
		} else {
			currentQuest = quest;
		}
	}

	public void EndQuest() {
		if(currentQuest != null) {
			currentQuest = null;
		}
	}
}
