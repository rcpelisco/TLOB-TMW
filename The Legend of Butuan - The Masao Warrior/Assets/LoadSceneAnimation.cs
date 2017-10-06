﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class LoadSceneAnimation : MonoBehaviour {

	public int requiredQuestID;

	private CharacterQuestModel questModel;
	private QuestData quest;
	private PlayableDirector director;

	void Awake() {
		questModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterQuestModel>();
		quest = questModel.GetMainQuest();
		director = GetComponent<PlayableDirector>();
	}

	void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode) {
		if(director == null) {
			return;
		}
		if(quest.ID == requiredQuestID) {
			director.Play();
		}
	}

	void OnEnable() {
		SceneManager.sceneLoaded += OnLevelFinishedLoading;
	}

	void Ondisable() {
		SceneManager.sceneLoaded -= OnLevelFinishedLoading;
	}

}
