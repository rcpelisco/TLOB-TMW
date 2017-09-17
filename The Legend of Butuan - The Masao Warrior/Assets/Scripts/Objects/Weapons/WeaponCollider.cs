using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WeaponCollider : MonoBehaviour {

	public ItemType itemType;

	Collider2D weaponCollider;

	void Awake() {
		weaponCollider = GetComponent<Collider2D>();
	}

	void OnTriggerEnter2D(Collider2D hitCollider) {
		AttackableBase attackable = hitCollider.gameObject.GetComponent<AttackableBase>();
		if(attackable != null) {
			attackable.OnHit(weaponCollider, itemType);
		}
	}
}
