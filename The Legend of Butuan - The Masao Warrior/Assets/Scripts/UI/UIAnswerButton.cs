using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIAnswerButton : MonoBehaviour {

	public Text answerText;

	private AnswerData data;
	private UIQuestion uIQuestion;

	void Start () {
		uIQuestion = GameObject.FindObjectOfType<UIQuestion>();
	}
	
	void Update () {
		
	}

	public void Setup(AnswerData newData) {
		data = newData;
		answerText.text = data.answerText;
	}

	public void HandleClick() {
		uIQuestion.AnswerButtonClicked(data.isCorrect);
	}


}
