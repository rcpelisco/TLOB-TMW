using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class InteractableNPC : InteractableBase {

	public Dialogue dialogue;
	public Transform notificationParent;
	public GameObject notificationBubble;
	public PlayableDirector animAfterDialogue;

	private bool isQuestActive;
	private CharacterMovementModel movementModel;
	private GameObject notification;
	private Item item;
	private Quest quest;
	private bool isDoneTalking;

	void Awake() {
		if(dialogue.speaker == null) {
			dialogue.speaker = gameObject;
		}
		quest = GetComponent<Quest>();
		item = GetComponent<Item>();
		movementModel = GetComponent<CharacterMovementModel>();
		if(quest == null) {
			return;
		}
		if(notificationParent != null) {
			notification = Instantiate(notificationBubble);
			notification.transform.parent = notificationParent;
			notification.transform.localPosition = Vector2.zero;
			notification.transform.localRotation = Quaternion.identity;
		}
	}

	void Update() {
		if(quest != null) {
			if(quest.quest.status == QuestData.QuestStatus.Available) {
				isQuestActive = true;
				Debug.Log("isQuestActive: " + isQuestActive);
			} else {
				isQuestActive = false;
			}
			notificationParent.gameObject.SetActive(isQuestActive);
		}
	}

	public override void OnInteract(Character character) {
		if(item != null){
			if(item.IsDone()) {
				return;
			}
		}
		if(quest != null) {
			if(quest.quest.status == QuestData.QuestStatus.Active || 
				quest.quest.status == QuestData.QuestStatus.Done) {
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
		notificationParent.gameObject.SetActive(false);
		if(FindObjectOfType<DialogueManager>().IsSentenceDone()) {
			FindObjectOfType<DialogueManager>().DisplayNextSentence();
			if(FindObjectOfType<DialogueManager>().IsDone()) {
				character.movementModel.SetFrozen(false, false);
				movementModel.SetFrozen(false, false);
				DialogueBox.Hide();
				if(animAfterDialogue != null) {
					animAfterDialogue.Play();
				}
				if(item != null) {
					item.Add(character);
				}
				if(quest != null) {
					quest.Add(character);
				}
			}
			return;
		}
		if(!FindObjectOfType<DialogueManager>().IsStarted()) {
			FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
			movementModel.SetFrozen(true, true);
			character.movementModel.SetFrozen(true, true);
		} else {
			FindObjectOfType<DialogueManager>().EndSentence();
		}
	}

	void FindCharacterFacing(Character character) {
		movementModel.SetDirection(character.movementModel.GetFacingDirection() * -1);
	}

	public bool IsDoneTalking() {
		return isDoneTalking;
	}

	public void SetDoneTalking(bool isDoneTalking) {
		this.isDoneTalking = isDoneTalking;
	}
}