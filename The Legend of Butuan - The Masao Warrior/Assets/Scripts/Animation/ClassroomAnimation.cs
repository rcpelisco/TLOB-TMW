using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClassroomAnimation : MonoBehaviour {

	public Dialogue[] dialogue;
	int index;
	
	void Start() {
		FadeManager.instance.Fade(false, 1.5f);
		index = 0;
		StartCoroutine(StartDialogueSequence());
	}

	void Update() { 
		if(FadeManager.instance.IsFading()) {
			return;
		}
		if(Input.GetKeyDown(KeyCode.E)) {
			InitiateDialogue();
		}
	}

	IEnumerator StartDialogueSequence(){
		yield return new WaitForSeconds(1.5f);
		InitiateDialogue();
	}

	IEnumerator EndScene() {
		FadeManager.instance.Fade(true, 2f);
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("IntroMuseumOut");
	}

	public void InitiateDialogue() {
		dialogue[index].speaker.GetComponentInChildren<Animator>().SetBool("isWalking", true);
		if(index == dialogue.Length) {
			return;
		}
		if(FindObjectOfType<DialogueManager>().IsSentenceDone()) {
			FindObjectOfType<DialogueManager>().DisplayNextSentence();
			if(FindObjectOfType<DialogueManager>().IsDone()) {
				dialogue[index].speaker.GetComponentInChildren<Animator>().SetBool("isWalking", false);
				index++;
				if(index == dialogue.Length) {
					DialogueBox.Hide();
					StartCoroutine(EndScene());
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

	void UpdateAnimation() {

	}
}
