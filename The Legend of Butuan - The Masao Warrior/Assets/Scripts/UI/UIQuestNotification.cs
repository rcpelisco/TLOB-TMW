using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuestNotification : MonoBehaviour {

	public Text questStatus;
	public Text questTitle;

	private Animator animator;

	void Awake() {
		animator = GetComponent<Animator>();
	}

	public void Show(QuestData.QuestStatus questStatus, string questTitle) {
		animator.SetBool("hide", false);
		if(questStatus == QuestData.QuestStatus.Active) {
			this.questStatus.text = "Quest Started";
		} else if(questStatus == QuestData.QuestStatus.Done) {
			this.questStatus.text = "Quest Completed";
		}
		this.questTitle.text = questTitle;
		animator.SetBool("show", true);
		StartCoroutine(Hide());
	}

	IEnumerator Hide() {
		yield return new WaitForSeconds(2f);
		animator.SetBool("show", false);
		animator.SetBool("hide", true);
	}
}
