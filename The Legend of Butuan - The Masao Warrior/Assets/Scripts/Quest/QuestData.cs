using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData {

	public int ID;
	public string title;
	
	[TextArea(0,3)]
	public string description;
	public int nextQuest;
	public Sprite giver;

	public int expReward;
	public ItemType itemReward;
	public int amountReward;

}
