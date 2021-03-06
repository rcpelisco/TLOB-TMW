﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuestButton : MonoBehaviour {

	public Button button;
	public Text questTitle;

	private QuestData data;
	private UIQuest uiQuest;

	void Start() {
		button.onClick.AddListener(HandleClick);
	}

	public void Setup(QuestData data, UIQuest uiQuest) {
		this.data = data;
		this.uiQuest = uiQuest;
		if(data != null) {
			questTitle.text = data.title;
		} else {
			questTitle.text = "No Active Quest";
		}
	}

	public void HandleClick() {
		uiQuest.SetRightPanel(data);
	}
}
