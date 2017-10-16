using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealthModel : MonoBehaviour {

	public float startingHealth;

	private float maximumHealth;
	private float health;
	private CharacterMovementView movementView;
	private PauseManager pauseManager;

	void Awake() {
		pauseManager = FindObjectOfType<PauseManager>().GetComponent<PauseManager>();
	}

	void Start () {
		movementView = GetComponent<CharacterMovementView>();
		maximumHealth = startingHealth;
		health = maximumHealth;
	}

	void Update () {
		
	}

	public float GetHealth() {
		return health;
	}

	public float GetMaxHealth() {
		return maximumHealth;
	}
	
	public float GetHealthPercentage() {
		return health / maximumHealth;
	}

	public void SetMaxHealth(float newMaxHealth) {
		maximumHealth = newMaxHealth;
	}

	public void SetHealth(float newHealth) {
		health = newHealth;
	}

	public void DealDamage(float damage) {
		if(health <= 0) {
			return;
		}
		UIDamageNumbers.Instance.ShowDamageNumber( damage, transform.position);
		health -= damage;
		if(health <= 0) {
			health = 0;
			movementView.OnDeath();
			StartCoroutine(WaitNextScene());
		}
	}
	
	IEnumerator WaitNextScene() {
		yield return new WaitForSeconds(2f);
		FadeManager.instance.Fade(true, 1.5f);
		pauseManager.ShowGameOverScreen();
	}
}
