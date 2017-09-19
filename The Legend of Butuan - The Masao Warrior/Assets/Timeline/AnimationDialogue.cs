using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class AnimationDialogue : MonoBehaviour {

	public PlayableDirector playable;
	public Dialogue[] dialogue;
	int index = 0;
	
	void OnEnable() {
		NextSentence();
	}

	public void NextSentence() {
		if(index == dialogue.Length) {
			return;
		}
		if(FindObjectOfType<DialogueManager>().IsSentenceDone()) {
			FindObjectOfType<DialogueManager>().DisplayNextSentence();
			if(FindObjectOfType<DialogueManager>().IsDone()) {
				index++;
				if(index == dialogue.Length) {
					DialogueBox.Hide();
					Play();
					return;
				}
				FindObjectOfType<DialogueManager>().StartDialogue(dialogue[index]);
			}
			return;
		}
		if(!FindObjectOfType<DialogueManager>().IsStarted()) {
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue[index]);
		} else {
			FindObjectOfType<DialogueManager>().EndSentence();
		}
	}

	void Play() {
		if(playable != null) {
			playable.Play();
		}
	}
}
