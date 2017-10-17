using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

	private Queue<string> sentences;
	private string currentSentence;
	private bool isStarted;
	private bool isSentenceDone;
	private bool isDone;
	private CharacterInteractionModel interactionModel;

	public float letterInterval = 0.05f;

	void Start() {
		sentences = new Queue<string>();
		interactionModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterInteractionModel>();
	}

	public void OnInteract() {
		if(interactionModel != null) {
			interactionModel.OnInteract();
		}
	}

	public void StartDialogue(Dialogue dialogue) {
		isDone = false;
		sentences.Clear();
		foreach(string sentence in dialogue.sentences) {
			sentences.Enqueue(sentence);
		}
		DialogueBox.Show();
		Sprite sprite = dialogue.speaker.GetComponentInChildren<Image>().sprite;
		if(sprite != null) {
			DialogueBox.SetAvatar(sprite);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence() {
		if(sentences.Count == 0) {
			EndDialogue();
			return;
		}
		isStarted = true;
		currentSentence = sentences.Dequeue();
		StopAllCoroutines();
		DialogueBox.ShowNextButton("Next >");
		StartCoroutine(TypeSentence(currentSentence));
	}

	public void EndSentence() {
		isSentenceDone = true;
		StopAllCoroutines();
		if(sentences.Count == 0) {
			DialogueBox.ShowNextButton("Close");
		}
		DialogueBox.SetText(currentSentence);
	}

	public void EndDialogue() {
		isStarted = false;
		isSentenceDone = false;
		isDone = true;
	}

	IEnumerator TypeSentence(string sentence) {
		isSentenceDone = false;
		DialogueBox.SetText("");
		foreach(char letter in sentence) {
			string temp = DialogueBox.GetText();
			DialogueBox.SetText(temp += letter);
			yield return new WaitForSeconds(letterInterval);
		}
		isSentenceDone = true;
	}

	public bool IsStarted() {
		return isStarted;
	}

	public bool IsSentenceDone() {
		return isSentenceDone;
	}

	public bool IsDone() {
		return isDone;
	}
}
