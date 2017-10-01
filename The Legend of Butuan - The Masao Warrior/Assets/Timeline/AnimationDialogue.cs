using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class AnimationDialogue : MonoBehaviour {

	public PlayableDirector playable;
	public Dialogue[] dialogue;
	public GameObject[] toDestroyOnStop;
	public bool stopOnDone;

	private int index = 0;
	private GameObject animationCanvas;

	void OnEnable() {
		animationCanvas = GameObject.FindGameObjectWithTag("AnimationCanvas");
		NextSentence();
	}

	public void NextSentence() {
		Debug.Log("Hello");
		if(index == dialogue.Length) {
			return;
		}
		if(animationCanvas.GetComponent<AnimationDialogueManager>().IsSentenceDone()) {
			animationCanvas.GetComponent<AnimationDialogueManager>().DisplayNextSentence();
			if(animationCanvas.GetComponent<AnimationDialogueManager>().IsDone()) {
				index++;
				if(index == dialogue.Length) {
					DialogueBox.Hide();
					if(stopOnDone) {
						Stop();
					} else {
						Play();
					}
					return;
				}
				animationCanvas.GetComponent<AnimationDialogueManager>().StartDialogue(dialogue[index]);
			}
			return;
		}
		if(!animationCanvas.GetComponent<AnimationDialogueManager>().IsStarted()) {
			animationCanvas.GetComponent<AnimationDialogueManager>().StartDialogue(dialogue[index]);
		} else {
			animationCanvas.GetComponent<AnimationDialogueManager>().EndSentence();
		}
	}

	void Play() {
		if(playable != null) {
			playable.Play();
		}
	}

	void Stop() {
		for(int i = 0; i < toDestroyOnStop.Length; i++) {
			Destroy(toDestroyOnStop[i]);
		}
	}
}
