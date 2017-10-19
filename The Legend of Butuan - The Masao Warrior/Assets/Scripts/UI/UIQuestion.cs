using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuestion : MonoBehaviour {

	public Text question;
	public List<GameObject> choices;
	public List<Question> questions;

	private Question[] questionArray;

	void OnEnable() {
		questionArray = questions.ToArray();
		SetQuestion();
	}

	void SetQuestion() {
		int temp = Random.Range(0, questions.Count-1);
		Debug.Log(temp);
		Question selected = questionArray[temp];
		question.text = selected.question;
	}
}