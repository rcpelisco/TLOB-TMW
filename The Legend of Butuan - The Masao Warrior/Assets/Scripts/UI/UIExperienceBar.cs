using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIExperienceBar : MonoBehaviour {

	public Text XPText;
	public Text LevelText;
	public RectTransform XPBar;

	private CharacterLevelModel levelModel;	


	void Awake () {
		levelModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterLevelModel>();
	}
	
	void Update () {
		UpdateText();
		UpdateXPBar();
	}

	void UpdateText() {
		if(XPText == null || LevelText == null) {
			Debug.LogError("Experience UI Elements not set up!", gameObject);
			return;
		}
		XPText.text = Mathf.RoundToInt(levelModel.GetCurrentExp()) + "/" + Mathf.RoundToInt(levelModel.GetRequiredExp()); 
		LevelText.text = levelModel.GetCurrentLevel() + "";
	}

	void UpdateXPBar() {
		if(XPBar == null) {
			Debug.LogError("Experience UI Elements not set up!", gameObject);
			return;
		}
		XPBar.localScale = new Vector3(levelModel.GetExpPercentage(), 1f, 1f);
	}
}
