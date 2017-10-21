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
	private GameObject mainQuestButton;
	private List<GameObject> sideQuestButtons;
	private List<QuestData> sideQuest;

	void Awake() {
		mainQuest = new QuestData();
		sideQuest = new List<QuestData>();
		sideQuestButtons = new List<GameObject>();
		questModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterQuestModel>();
	}

	void Start() {
		RefreshDisplay();
	}

	void OnEnable(){
		if(questModel != null) {
			sideQuest = questModel.GetSideQuest();
			mainQuest = questModel.GetMainQuest();
		}
		RefreshDisplay();
	}

	public void RefreshDisplay() {
		RemoveQuestButtons();
		AddSideQuestButtons();
		SetMainQuestButton();
	}

	private void RemoveQuestButtons() {
		foreach(Transform child in sideQuestParent.transform) {
			Destroy(child.gameObject);
		}
	}

	private void AddSideQuestButtons() {
		if(sideQuest == null) {
			return;
		}
		foreach(QuestData data in sideQuest) {
			if(data.status != QuestData.QuestStatus.Done) {
				GameObject questButton = (GameObject) GameObject.Instantiate(buttonPrefab);
				UIQuestButton uiQB = questButton.GetComponent<UIQuestButton>();
				questButton.transform.SetParent(sideQuestParent);
				questButton.transform.localScale = Vector3.one;
				uiQB.Setup(data, this);
				sideQuestButtons.Add(questButton);
			}
		}
	}

	private void SetMainQuestButton() {
		if(mainQuestButton == null) {
			mainQuestButton = (GameObject) GameObject.Instantiate(buttonPrefab);
		}
		UIQuestButton uiQB = mainQuestButton.GetComponent<UIQuestButton>();
		mainQuestButton.transform.SetParent(mainQuestParent);
		mainQuestButton.transform.localScale = Vector3.one;
		uiQB.Setup(mainQuest, this);
		SetRightPanel(mainQuest);
	}

	public void SetRightPanel(QuestData data) {
		if(data == null) {
			return;
		}
		title.text = data.title;
		desc.text = data.description;
		xP.text = data.expReward.ToString();
		item.text = data.itemReward.ToString();
		amount.text = data.amountReward.ToString();
	}
}
