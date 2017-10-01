using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationDialogueManager : MonoBehaviour {

	private Queue<string> sentences;
	private string currentSentence;
	private bool isStarted;
	private bool isSentenceDone;
	private bool isDone;
	private GameObject goldCount;

	public float letterInterval = 0.05f;

	void Awake() {
		sentences = new Queue<string>();
		goldCount = GameObject.FindGameObjectWithTag("GoldCount");
	}

	public void StartDialogue(Dialogue dialogue) {
		isDone = false;
		sentences.Clear();
		foreach(string sentence in dialogue.sentences) {
			sentences.Enqueue(sentence);
		}
		AnimationDialogueBox.Show();
		if(goldCount != null) {
			goldCount.SetActive(false);
		}
		Sprite sprite = dialogue.speaker.GetComponentInChildren<Image>().sprite;
		if(sprite != null) {
			AnimationDialogueBox.SetAvatar(sprite);
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
		AnimationDialogueBox.ShowNextButton("Next >");
		StartCoroutine(TypeSentence(currentSentence));
	}

	public void EndSentence() {
		isSentenceDone = true;
		StopAllCoroutines();
		if(sentences.Count == 0) {
			AnimationDialogueBox.ShowNextButton("Close");
		}
		AnimationDialogueBox.SetText(currentSentence);
	}

	public void EndDialogue() {
		isStarted = false;
		isSentenceDone = false;
		isDone = true;
		if(goldCount != null) {
			goldCount.SetActive(true);
		}
	}

	IEnumerator TypeSentence(string sentence) {
		isSentenceDone = false;
		AnimationDialogueBox.SetText("");
		foreach(char letter in sentence) {
			string temp = AnimationDialogueBox.GetText();
			AnimationDialogueBox.SetText(temp += letter);
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
