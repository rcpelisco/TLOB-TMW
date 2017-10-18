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
	private List<Button> sideQuestButtons;
	private List<QuestData> sideQuest;

	void Awake() {
		sideQuest = new List<QuestData>();
		// questModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterQuestModel>();
	}

	void Start() {
		QuestData data = new QuestData();
		data.ID = 100;
		data.title = "A Link to the Past";
		data.description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec elementum purus nisl, dictum tempor massa facilisis vitae. Morbi ac ex eu ipsum imperdiet rhoncus vel at turpis. Pellentesque justo lectus, elementum ultrices luctus mollis, lacinia at libero. Aliquam nibh eros, blandit maximus urna dapibus, placerat feugiat ligula. Curabitur ut scelerisque orci. Phasellus maximus metus id dignissim egestas. Curabitur ornare urna eget nulla pretium ultrices. Vivamus justo nunc, convallis quis interdum ut, maximus sit amet enim. Morbi quis pretium orci. In nunc eros, bibendum nec augue ac, bibendum interdum libero. Nulla sit amet erat turpis. Donec accumsan fringilla lacus sed laoreet. Aenean odio metus, porttitor a dapibus ut, euismod in purus. Nullam consequat risus sit amet porta faucibus. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Morbi ac pharetra urna.";
		data.nextQuest = 0;
		data.requirement = "";
		data.objective = "";
		data.enemyType = EnemyType.None;
		data.type = QuestData.QuestType.SideQuest;
		data.status = QuestData.QuestStatus.Available;
		data.expReward = 100;
		data.itemReward = ItemType.None;
		data.amountReward = 0;
		sideQuest.Add(data);
		RefreshDisplay();
	}

	void RefreshDisplay() {
		RemoveQuestButtons();
		AddSideQuestButtons();
	}

	void OnEnable() {
		SetQuest();
	}

	private void RemoveQuestButtons() {
		while(sideQuestParent.childCount > 0) {
			GameObject toRemove = sideQuestParent.GetChild(0).gameObject;
			Destroy(toRemove);
		}
	}

	private void AddSideQuestButtons() {
		foreach(QuestData data in sideQuest) {
			GameObject questButton = (GameObject) GameObject.Instantiate(buttonPrefab);
			questButton.transform.SetParent(sideQuestParent);
			questButton.transform.localScale = Vector3.one;
			UIQuestButton uiQB = questButton.GetComponent<UIQuestButton>();
			uiQB.Setup(data, this);
		}
	}

	public void SetRightPanel(QuestData data) {
		title.text = data.title;
		desc.text = data.description;
		xP.text = data.expReward.ToString();
		item.text = data.itemReward.ToString();
		amount.text = data.amountReward.ToString();
	}

	public void SetQuest() {
		// questData = questModel.GetMainQuest();
		// if(questData != null) {
		// 	text.text = questData.description;
		// } else {
		// 	text.text = "No active quest";
		// }
	}
}
