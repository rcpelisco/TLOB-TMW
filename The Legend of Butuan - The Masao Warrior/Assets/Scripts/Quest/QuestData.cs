using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData {

	public enum QuestType {
		MainQuest,
		SideQuest
	}

	public enum QuestStatus {
		Inactive,
		Active,
		Done
	}

	public int ID;
	public string title;
	
	[TextArea(0,3)]
	public string description;
	public int nextQuest;
	public Sprite giver;

	public string requirement;
	public string objective;
	public QuestType type;
	public QuestStatus status;

	public int expReward;
	public ItemType itemReward;
	public int amountReward;
}
