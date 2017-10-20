using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Narrator : MonoBehaviour {

	public float hideTime;
	public float showTime;
	public Dialogue dialogue;
	bool isVisible;
	Text text;
	FadeText fadeText;
	Queue<string> sentences;
	
	void Awake() {
		text = GetComponent<Text>();
		fadeText = new FadeText();
		sentences = new Queue<string>();
	}

	void Start() {
		text.color = new Color(text.color.r, text.color.g, 
			text.color.b, 0f);
		foreach(string sentence in dialogue.sentences) {
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}

	void DisplayNextSentence() {
		if(sentences.Count == 0) {
			SceneManager.LoadScene("MapOverview");
			return;
		}
		string sentence = sentences.Dequeue();
		text.text = sentence;
		StartCoroutine(ToggleSentence(showTime));
		StartCoroutine(DelayedDisplay(hideTime + 1 + showTime));
	}

	IEnumerator DelayedDisplay(float time) {
		yield return new WaitForSeconds(time);
		DisplayNextSentence();
	}

	IEnumerator ToggleSentence(float time) {
		StartCoroutine(fadeText.FadeTextToFullAlpha(1f, text));
		yield return new WaitForSeconds(time);
		StartCoroutine(fadeText.FadeTextToZeroAlpha(1f, text));
	}
}
