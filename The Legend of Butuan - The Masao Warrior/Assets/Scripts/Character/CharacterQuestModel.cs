using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterQuestModel : MonoBehaviour {

	private QuestData currentQuest;

	public void AddQuest(QuestData quest) {
		currentQuest = quest;
	}

	public void EndQuest() {
		currentQuest = null;
	}

	public QuestData GetQuestData() {
		return currentQuest;
	}
}
