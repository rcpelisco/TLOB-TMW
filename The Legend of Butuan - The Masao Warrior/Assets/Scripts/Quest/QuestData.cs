using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData {

	public int id;
	public string description;
	public int nextQuest;

	public string questObjective;
	public string questObjectiveRequirement;
	public string questObjectiveCount;

	public int expReward;
	public ItemType itemReward;
	public int amountReward;

}
