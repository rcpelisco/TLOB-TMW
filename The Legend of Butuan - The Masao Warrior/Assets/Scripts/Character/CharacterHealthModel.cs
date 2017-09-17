using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealthModel : MonoBehaviour {

	public float startingHealth;

	private float maximumHealth;
	private float health;

	void Start () {
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
			// Debug.Log("YOU DIED!");
			health = 0;
		}
	}
}
