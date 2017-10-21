using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour {

	public QuestData quest;
	
	private bool isDone;
	private CharacterQuestModel questModel;

	void Start() {
		questModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterQuestModel>();
	}

	void Update() {
		if(questModel.GetMainQuest() != null) {
			if(questModel.GetMainQuest().nextQuest == quest.ID) {
				quest.status = QuestData.QuestStatus.Available;
			}
		}
		if(quest.status == QuestData.QuestStatus.Available) {
			
		}
	}

	public void Add(Character character) {
		if(!isDone) {
			isDone = true;
			quest.status = QuestData.QuestStatus.Active;
			character.questModel.CheckProgress(quest);
		}
	}

	public void SetStatus(QuestData.QuestStatus status) {
		quest.status = status;
	}

	public bool IsDone() {
		return isDone;
	}
}
