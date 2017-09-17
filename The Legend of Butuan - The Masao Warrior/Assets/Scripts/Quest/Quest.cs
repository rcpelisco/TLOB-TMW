using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest {
	public enum QuestProgress {
		NOT_AVAILABLE,
		AVAILABLE,
		ACCEPT,
		COMPLETE,
		DONE
	}
	public string title;
	public int id;
	public QuestProgress progress;
	public string description;
	public int nextQuest;

	public string questObjective;
	public string questObjectiveRequirement;
	public string questObjectiveCount;

	public int expReward;
	public int goldReward;
	public int itemReward;


}
