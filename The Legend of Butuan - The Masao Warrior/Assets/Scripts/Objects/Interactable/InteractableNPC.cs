using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableNPC : InteractableBase {

	public Dialogue dialogue;
	public Transform notificationParent;
	public GameObject notificationBubble;

	private CharacterMovementModel movementModel;
	private GameObject notification;
	private Item item;

	void Awake() {
		if(dialogue.speaker == null) {
			dialogue.speaker = gameObject;
		}
		item = GetComponent<Item>();
		movementModel = GetComponent<CharacterMovementModel>();
		if(notificationParent != null) {
			notification = Instantiate(notificationBubble);
			notification.transform.parent = notificationParent;
			notification.transform.localPosition = Vector2.zero;
			notification.transform.localRotation = Quaternion.identity;
		}
	}

	public override void OnInteract(Character character) {
		if(item != null){
			if(item.IsDone()) {
				return;
			}
		}
		FindCharacterFacing(character);
		InitiateDialogue(character);
	}

	void InitiateDialogue(Character character) {
		if(dialogue.sentences.Length <= 0) {
			return;
		}
		Destroy(notification);
		if(FindObjectOfType<DialogueManager>().IsSentenceDone()) {
			FindObjectOfType<DialogueManager>().DisplayNextSentence();
			if(FindObjectOfType<DialogueManager>().IsDone()) {
				character.movementModel.SetFrozen(false);
				movementModel.SetFrozen(false);
				DialogueBox.Hide();
				if(item != null) {
					item.Add(character);
				}
			}
			return;
		}
		if(!FindObjectOfType<DialogueManager>().IsStarted()) {
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			movementModel.SetFrozen(true);
			character.movementModel.SetFrozen(true);
		} else {
			FindObjectOfType<DialogueManager>().EndSentence();
		}
	}

	void FindCharacterFacing(Character character) {
		movementModel.SetDirection(character.movementModel.GetFacingDirection() * -1);
	}
}