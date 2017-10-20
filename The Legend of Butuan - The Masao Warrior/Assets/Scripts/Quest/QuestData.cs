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
		Unavailable,
		Available,
		Active,
		Done
	}

	public int ID;
	public string title = "";
	
	[TextArea(0,3)]
	public string description = "";
	public int nextQuest;

	public string requirement;
	public string objective;
	public EnemyType enemyType;
	public int noOfEnemies;
	public QuestType type;
	public QuestStatus status;
	public string completeOnScene;

	public int expReward = 0;
	public ItemType itemReward = ItemType.None;
	public int amountReward = 0;
}
