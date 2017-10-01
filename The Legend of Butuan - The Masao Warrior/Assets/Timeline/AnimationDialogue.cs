using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class AnimationDialogue : MonoBehaviour {

	public PlayableDirector playable;
	public Dialogue[] dialogue;

	private int index = 0;
	private GameObject animationCanvas;

	void OnEnable() {
		animationCanvas = GameObject.FindGameObjectWithTag("AnimationCanvas");
		NextSentence();
	}

	public void NextSentence() {
		if(index == dialogue.Length) {
			return;
		}
		if(animationCanvas.GetComponent<DialogueManager>().IsSentenceDone()) {
			animationCanvas.GetComponent<DialogueManager>().DisplayNextSentence();
			if(animationCanvas.GetComponent<DialogueManager>().IsDone()) {
				index++;
				if(index == dialogue.Length) {
					DialogueBox.Hide();
					Play();
					return;
				}
				animationCanvas.GetComponent<DialogueManager>().StartDialogue(dialogue[index]);
			}
			return;
		}
		if(!animationCanvas.GetComponent<DialogueManager>().IsStarted()) {
			animationCanvas.GetComponent<DialogueManager>().StartDialogue(dialogue[index]);
		} else {
			animationCanvas.GetComponent<DialogueManager>().EndSentence();
		}
	}

	void Play() {
		if(playable != null) {
			playable.Play();
		}
	}
}
