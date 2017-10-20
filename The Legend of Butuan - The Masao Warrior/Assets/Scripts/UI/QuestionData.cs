using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionData {

	[TextArea(0,3)]
	public string question;
	public AnswerData[] choices;
	
}