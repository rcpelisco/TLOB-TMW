using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider) {
		if(collider.CompareTag("Player")) {
			collider.gameObject.GetComponent<CharacterHealthModel>().DealDamage(5f);
			Destroy(gameObject);
		}
	}
}
