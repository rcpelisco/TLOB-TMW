using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIQuest : MonoBehaviour {

	[Header("Buttons")]
	public GameObject buttonPrefab;
	public Transform mainQuestParent;
	public Transform sideQuestParent;

	[Header("Right Panel")]
	public Text title;
	public Text desc;
	public Text xP;
	public Text item;
	public Text amount;

	private CharacterQuestModel questModel;
	private QuestData mainQuest;
	private List<GameObject> sideQuestButtons;
	private List<QuestData> sideQuest;

	void Awake() {
		sideQuest = new List<QuestData>();
		sideQuestButtons = new List<GameObject>();
		questModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterQuestModel>();
	}

	void Start() {
		sideQuest = questModel.GetSideQuest();
		mainQuest = questModel.GetMainQuest();
		RefreshDisplay();
	}

	void RefreshDisplay() {
		RemoveQuestButtons();
		AddSideQuestButtons();
	}

	private void RemoveQuestButtons() {
		while(sideQuestParent.childCount > 0) {
			GameObject toRemove = sideQuestParent.GetChild(0).gameObject;
			Destroy(toRemove);
		}
	}

	private void AddSideQuestButtons() {
		foreach(QuestData data in sideQuest) {
			Debug.Log(data.title);
			GameObject questButton = (GameObject) GameObject.Instantiate(buttonPrefab);
			sideQuestButtons.Add(questButton);
			questButton.transform.SetParent(null);
			UIQuestButton uiQB = questButton.GetComponent<UIQuestButton>();
			uiQB.Setup(data, this);
		}
		foreach(GameObject questButton in sideQuestButtons) {
			questButton.transform.SetParent(sideQuestParent);
			questButton.transform.localScale = Vector3.one;
		}
	}

	public void SetRightPanel(QuestData data) {
		title.text = data.title;
		desc.text = data.description;
		xP.text = data.expReward.ToString();
		item.text = data.itemReward.ToString();
		amount.text = data.amountReward.ToString();
	}
}
