using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class AnimationDialogue : MonoBehaviour {

	public PlayableDirector playable;
	public Dialogue[] dialogue;
	public GameObject[] toDestroyOnStop;
	public Quest questOnDone;
	public bool stopOnDone;

	private int index = 0;
	private GameObject animationCanvas;
	private Character character;

	void OnEnable() {
		animationCanvas = GameObject.FindGameObjectWithTag("AnimationCanvas");
		if(GameObject.FindGameObjectWithTag("Player") != null) {
			character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
		}
		NextSentence();
	}

	public void NextSentence() {
		if(index == dialogue.Length) {
			return;
		}
		if(animationCanvas.GetComponent<AnimationDialogueManager>().IsSentenceDone()) {
			animationCanvas.GetComponent<AnimationDialogueManager>().DisplayNextSentence();
			if(animationCanvas.GetComponent<AnimationDialogueManager>().IsDone()) {
				index++;
				if(index == dialogue.Length) {
					AnimationDialogueBox.Hide();
					if(stopOnDone) {
						Stop();
					} else {
						Play();
					}
					if(questOnDone != null) {
						questOnDone.Add(character);
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
