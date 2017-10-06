using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour {

	public Text healthText;
	public RectTransform healthBar;

	private CharacterHealthModel healthModel;

	void Awake() {
		healthModel = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterHealthModel>();
	}

	void Update() {
		UpdateText();
		UpdateHealthBar();
	}

	void UpdateText() {
		healthText.text = Mathf.RoundToInt(healthModel.GetHealth()) + "/" + Mathf.RoundToInt(healthModel.GetMaxHealth());	
	}

	void UpdateHealthBar() {
		healthBar.localScale = new Vector3( healthModel.GetHealthPercentage(), 1f, 1f);
	}
}
