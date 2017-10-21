using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealthModel : MonoBehaviour {

	public float startingHealth;
	public AudioSource[] isHitAudio;
	public AudioSource playerDeathAudio;

	private float maximumHealth;
	private float health;
	private CharacterMovementView movementView;
	private CharacterMovementModel movementModel;
	private PauseManager pauseManager;
	private GameStateManager stateManager;
	private bool isDead;

	void Awake() {
		movementView = GetComponent<CharacterMovementView>();
		movementModel = GetComponent<CharacterMovementModel>();
		stateManager = GameObject.FindObjectOfType<GameStateManager>() as GameStateManager;
		maximumHealth = startingHealth;
		ResetHealth();
	}

	void Start() {
		pauseManager = FindObjectOfType<PauseManager>().GetComponent<PauseManager>();
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
		if(isDead){ 
			return;
		}
		int audioRandom = Random.Range(0, isHitAudio.Length);
		UIDamageNumbers.Instance.ShowDamageNumber(damage, transform.position);
		isHitAudio[audioRandom].Play();
		health -= damage;
		if(health <= 0) {
			health = 0;
			isDead = true;
			playerDeathAudio.Play();
			movementView.OnDeath();
			StartCoroutine(DeathAnimWait());
			StartCoroutine(WaitNextScene());
		}
	}

	public void ResetHealth() {
		health = maximumHealth;
	}

	IEnumerator DeathAnimWait() {
		yield return new WaitForSeconds(1f);
		movementModel.SetFrozen(true, true);
		stateManager.DeathSave();
	}
	
	IEnumerator WaitNextScene() {
		yield return new WaitForSeconds(1.5f);
		FadeManager.instance.Fade(true, 1.5f);
		pauseManager.ShowGameOverScreen();
	}
}
