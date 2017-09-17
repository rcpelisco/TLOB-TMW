// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class SpeakerManager : MonoBehaviour {
	
// 	public Queue<Dialogue> speakers;
// 	private bool isDialogueDone;
// 	float textSpeed;
// 	public DialogueManager dialogueManager;
// 	Animator animator;

// 	void Awake() {
// 		speakers = new Queue<Dialogue>();
// 		dialogueManager = FindObjectOfType<DialogueManager>();
// 		animator = GetComponentInChildren<Animator>();
// 	}

// 	public void StartSpeaker(Dialogue[] dialogue, float textSpeed) {
// 		this.textSpeed = textSpeed;
// 		isDialogueDone = false;
// 		for(int i = 0; i < dialogue.Length; i++) {
// 			speakers.Enqueue(dialogue[i]);
// 		}
// 		Debug.Log(speakers.Count);
// 		NextSpeaker();
// 	}

// 	public void NextSpeaker() {
// 		if(speakers.Count == 0) {
// 			isDialogueDone = true;
// 			EndAllDialogue();
// 			return;
// 		}
// 		Dialogue dialogue = speakers.Dequeue();
// 		dialogueManager.StartDialogue(dialogue, textSpeed);
// 		animator.SetBool("isOpen", true);
// 	}

// 	public bool IsSpeakerDone() {
// 		return dialogueManager.IsDone();
// 	}

// 	public bool IsDialogueDone() {
// 		return isDialogueDone;
// 	}

// 	void EndAllDialogue() {
// 		animator.SetBool("isOpen", false);
// 	}

// 	public bool IsOpen() {
// 		return animator.GetBool("isOpen");
// 	}
// }
