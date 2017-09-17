using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour {

	public CharacterHealthModel healthModel;
	public Text healthText;
	public RectTransform healthBar;

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
