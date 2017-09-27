using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuest : MonoBehaviour {

	[SerializeField]
	private Image avatar;

	[SerializeField]
	private Text text;

	private CharacterQuestModel questModel;
	private QuestData questData;

	void Awake() {
		questModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterQuestModel>();
	}

	void OnEnable() {
		SetQuest();
	}

	public void SetQuest() {
		questData = questModel.GetQuestData();
		if(questData != null) {
			text.text = questData.description;
			avatar.color = new Color(1, 1, 1, 1);
			avatar.sprite = questData.giver;
		} else {
			text.text = "No active quest";
			avatar.color = new Color(0, 0, 0, 0);
		}
	}

}
