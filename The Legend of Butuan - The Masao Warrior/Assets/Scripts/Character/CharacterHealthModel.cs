using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealthModel : MonoBehaviour {

	public float startingHealth;

	private float maximumHealth;
	private float health;
	private CharacterMovementView movementView;
	private GameStateManager stateManager;

	void Start () {
		movementView = GetComponent<CharacterMovementView>();
		stateManager = GetComponent<GameStateManager>();
		maximumHealth = startingHealth;
		health = maximumHealth;
	}

	void Update () {
		if( Input.GetKeyDown( KeyCode.T) )
		{
			DealDamage(10);
		}

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

	public void DealDamage(float damage) {
		if(health <= 0) {
			return;
		}
		UIDamageNumbers.Instance.ShowDamageNumber( damage, transform.position);
		health -= damage;
		Debug.Log(health);
		if(health <= 0) {
			health = 0;
			movementView.OnDeath();
			StartCoroutine(WaitNextScene());
		}
	}
	
	IEnumerator WaitNextScene() {
		FadeManager.instance.Fade(true, 1.5f);
		yield return new WaitForSeconds(3f);
		FadeManager.instance.Fade(false, 1.5f);
		stateManager.GameOver();

	}
}
