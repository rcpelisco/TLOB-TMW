using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddQuestOnEnable : MonoBehaviour {

	private CharacterQuestModel questModel;
	private Quest quest;

	void Awake() {
		questModel = FindObjectOfType<CharacterQuestModel>();
		quest = GetComponent<Quest>();
	}

	void OnEnable() {
		questModel.CheckProgress(quest.quest);
	}
}
