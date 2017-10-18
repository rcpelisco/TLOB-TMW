using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour {

	public QuestData quest;
	
	private bool isDone;
	private Image avatar;
	private CharacterQuestModel questModel;

	void Awake() {
		questModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterQuestModel>();
		avatar = GetComponentInChildren<Image>();
		if(questModel.GetSideQuest().Contains(quest)) {
			Debug.Log("Naa na ni");
			this.enabled = false;
		}
	}

	void Update() {
		if(questModel.GetMainQuest() != null) {
			if(questModel.GetMainQuest().nextQuest == quest.ID) {
				quest.status = QuestData.QuestStatus.Available;
			}
		}
	}

	public void Add(Character character) {
		if(!isDone) {
			isDone = true;
			quest.status = QuestData.QuestStatus.Active;
			character.questModel.CheckProgress(quest);
		}
	}

	public bool IsDone() {
		return isDone;
	}
}
