using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIQuestion : MonoBehaviour {

	[Header("Prefab")]
	public GameObject buttonPrefab;

	[Space]
	public Text question;
	public Transform answerButtonParent;
	public QuestionData[] questionPool;

	private List<GameObject> answerButtonGameObjects = new List<GameObject>();

	void Start() {
		RemoveAnswerButtons();
		SetQuestion();
	}

	void SetQuestion() {
		int temp = Random.Range(0, questionPool.Length);
		QuestionData questionData = questionPool[temp];
		question.text = questionData.question;
		AnswerData[] randomChoices = ShuffleAnswers(questionData.choices);
		for(int i = 0; i < questionData.choices.Length; i++) {
			GameObject button = Instantiate(buttonPrefab);
			button.transform.SetParent(answerButtonParent);
			button.transform.localScale = Vector3.one;
			answerButtonGameObjects.Add(button);

			UIAnswerButton answerButton = button.GetComponent<UIAnswerButton>();
			answerButton.Setup(randomChoices[i]);
		}
	}

	AnswerData[] ShuffleAnswers(AnswerData[] data) {
		List<int> done = new List<int>();
		for(int i = 0; i < data.Length; i++) {
			int r = Random.Range(0, data.Length);
			while(done.Contains(r)) {
				r = Random.Range(0, data.Length);
			}
			done.Add(r);
			AnswerData temp = data[i];
			data[i] = data[r];
			data[r] = temp;
		}
		return data;
	}

	void RemoveAnswerButtons() {
		foreach(GameObject button in answerButtonGameObjects) {
			Destroy(button);
		}
	}

	public void AnswerButtonClicked(bool isCorrect) {
		if(isCorrect) {
			SceneManager.LoadScene("GameOver");
		}
	}


}