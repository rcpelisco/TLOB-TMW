using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Question {

	[TextArea(0,3)]
	public string question;
	public List<string> answer;
	public int answerIndex;
	
}