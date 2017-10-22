using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterQuestModel : MonoBehaviour {
	
	public int killedEnemy;
	public AudioSource questAudio;

	private QuestData mainQuest;
	private List<QuestData> sideQuests;
	private Quest[] quests;
	private Dictionary<EnemyType, int> killCount;

	private CharacterLevelModel levelModel;
	private CharacterInventoryModel inventoryModel;
	private UIQuestNotification questNotification;

	void Awake() {
		levelModel = GetComponent<CharacterLevelModel>();
		inventoryModel = GetComponent<CharacterInventoryModel>();
		questNotification = FindObjectOfType<UIQuestNotification>();
		killCount = new Dictionary<EnemyType, int>();
		sideQuests = new List<QuestData>();
	}

	void OnEnable() {
		SceneManager.sceneLoaded += SceneFinishLoading;
	}

	void OnDisable() {
		SceneManager.sceneLoaded -= SceneFinishLoading;
	}

	void SceneFinishLoading(Scene scene, LoadSceneMode mode) {
		quests = FindQuestGivers();
		SetAllStatus();
		CheckSceneQuest();
	}

	public void AddKilledEnemy(EnemyType enemy) {
		if(killCount.ContainsKey(enemy)) {
			Debug.Log("new: " + enemy);
			killCount[enemy] += 1;
		} else {
			Debug.Log("add: " + enemy);
			killCount.Add(enemy, 1);
		}
		CheckEnemyKills();
	}

	void CheckEnemyKills() {
		foreach(QuestData data in sideQuests.ToArray()) {
			if(killCount.ContainsKey(data.enemyType)) {
				if(killCount[data.enemyType] >= data.noOfEnemies) {
					Debug.Log(data.enemyType);
					EndQuest(data);
					killCount[data.enemyType] = 0;
				}
			}
		}
	}	

	void CheckSceneQuest() {
		string sceneName = SceneManager.GetActiveScene().name;
		foreach(QuestData data in sideQuests.ToArray()) {
			if(data.completeOnScene == sceneName) {
				EndQuest(data);
			}
		}
	}

	void SetAllStatus() {
		for(int i = 0; i < quests.Length; i++) {
			Quest q = quests[i];
			foreach(QuestData data in sideQuests.ToArray()) {
				if(IsQuestAlreadyAdded(data, q.quest)) {
					q.SetStatus(QuestData.QuestStatus.Active);
				} else if(IsQuestAlreadyDone(data.ID, q.quest.ID)) {
					q.SetStatus(QuestData.QuestStatus.Done);
				} else if(q.quest.status == QuestData.QuestStatus.Unavailable) {
					if(q.quest.ID == data.ID + 1) {
						q.SetStatus(QuestData.QuestStatus.Available);
					}
				} 
			}
		}
	}

	Quest[] FindQuestGivers() {
		return GameObject.FindObjectsOfType<Quest>();
	}

	void AddQuest(QuestData quest) {
		Debug.Log("AddQuest");
		questNotification.Show(quest.status, quest.title);
		if(quest.type == QuestData.QuestType.MainQuest) {
			mainQuest = quest;

		} else if(quest.type == QuestData.QuestType.SideQuest) {
			if(sideQuests.Count == 0) {
				sideQuests.Add(quest);
			}
			foreach(QuestData data in sideQuests.ToArray()) {
				if(IsQuestAlreadyAdded(data, quest)) {
					return;
				}
				sideQuests.Add(quest);
			}
		}
	}

	bool IsQuestAlreadyAdded(QuestData data, QuestData quest) {
		if(data.ID == quest.ID) {
			return true;
		}
		return false;
	}

	bool IsQuestAlreadyDone(int id, int otherID) {
		if(id == otherID) {
			return true;
		}
		return false;
	}

	void EndQuest(QuestData quest) {
		SetAllStatus();
		if(quest.status == QuestData.QuestStatus.Done) {
			return;
		}
		if(quest.type == QuestData.QuestType.MainQuest) {
			quest = null;
		} else if(quest.type == QuestData.QuestType.SideQuest) {
			inventoryModel.AddItem(quest.itemReward, quest.amountReward);
			levelModel.AddExp(quest.expReward);
			quest.status = QuestData.QuestStatus.Done;
		}
		questNotification.Show(quest.status, quest.title);
	}

	public void CheckProgress(QuestData quest) {
		if(quest.type == QuestData.QuestType.MainQuest) {
			if(mainQuest == null) {
				AddQuest(quest);
				return;
			}
			if(mainQuest.objective == quest.requirement) {
				AddQuest(quest);
			}
		}else if(quest.type == QuestData.QuestType.SideQuest) {
			AddQuest(quest);
		}
	}

	public void SetMainQuest(QuestData data) {
		mainQuest = data;
	}

	public void SetSideQuest(List<QuestData> data) {
		sideQuests = data;
	}

	public QuestData GetMainQuest() {
		return mainQuest;
	}

	public List<QuestData> GetSideQuest() {
		return sideQuests;
	}
}
