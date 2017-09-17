using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

	public static QuestManager questManager;
	List<Quest> quests = new List<Quest>();
	List<Quest> currentQuest = new List<Quest>();

	void Awake() {
		if(questManager == null) {
			questManager = this;
		} else if(questManager != this) {
			Destroy(gameObject);
		}
		DontDestroyOnLoad(gameObject);
	}

	public void AddQuestItem(string questObjective, int amount) {
		for(int i = 0; i < currentQuest.Count; i++) {
			if(currentQuest[i].questObjective == questObjective && currentQuest[i].progress == Quest.QuestProgress.ACCEPT);
		}
	}

	public bool RequestAvailableQuest(int questID) {
		for(int i = 0; i < quests.Count; i++) {
			if(quests[i].id == questID && quests[i].progress == Quest.QuestProgress.AVAILABLE) {
				return true;
			}
		}
		return false;
	}

	public bool RequestAcceptedQuest(int questID) {
		for(int i = 0; i < quests.Count; i++) {
			if(quests[i].id == questID && quests[i].progress == Quest.QuestProgress.ACCEPT) {
				return true;
			}
		}
		return false;
	}

	public bool RequestCompleteQuest(int questID) {
		for(int i = 0; i < quests.Count; i++) {
			if(quests[i].id == questID && quests[i].progress == Quest.QuestProgress.COMPLETE) {
				return true;
			}
		}
		return false;
	}

}
