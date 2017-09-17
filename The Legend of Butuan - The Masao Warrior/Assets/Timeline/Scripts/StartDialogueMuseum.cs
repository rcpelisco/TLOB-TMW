using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartDialogueMuseum : MonoBehaviour {

	public Dialogue dialogue;

	void OnEnable() {
		FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
	}
}
