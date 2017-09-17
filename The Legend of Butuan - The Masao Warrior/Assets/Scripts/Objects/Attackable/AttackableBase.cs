using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableBase : MonoBehaviour {

	public virtual void OnHit(Collider2D hitCollider, ItemType item) {
		Debug.LogWarning("Warning: No OnHit event setup for " + gameObject.name);
	}
}
