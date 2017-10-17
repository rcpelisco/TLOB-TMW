using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterQuestModel : MonoBehaviour {
	
	private QuestData mainQuest;
	private List<QuestData> sideQuests;

	void Awake() {
		sideQuests = new List<QuestData>();
	}

	void AddQuest(QuestData quest) {
		if(quest.type == QuestData.QuestType.MainQuest) {
			mainQuest = quest;
		} else if(quest.type == QuestData.QuestType.SideQuest) {
			sideQuests.Add(quest);
		}
	}

	void EndQuest(QuestData quest) {
		if(quest.type == QuestData.QuestType.MainQuest) {
			quest = null;
		} else if(quest.type == QuestData.QuestType.SideQuest) {
			sideQuests.Remove(quest);
		}
	}

	public void CheckProgress(QuestData quest) {
		if(quest.type == QuestData.QuestType.MainQuest) {
			if(mainQuest == null) {
				AddQuest(quest);
				return;
			}
			if(mainQuest.objective == quest.requirement) {
				AddQuest(quest);
			}
		}else if(quest.type == QuestData.QuestType.SideQuest) {
			AddQuest(quest);
		}
	}

	public QuestData GetMainQuest() {
		return mainQuest;
	}

	public List<QuestData> GetSideQuest() {
		return sideQuests;
	}
}
