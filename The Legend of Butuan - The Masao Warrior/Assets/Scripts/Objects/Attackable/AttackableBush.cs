using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackableBush : AttackableBase {

	public Sprite destroyedSprite;
	public GameObject destroyedEffects;

	private SpriteRenderer spriteRenderer;

	void Awake() {
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	public override void OnHit(Collider2D hitCollider, ItemType item) {
		spriteRenderer.sprite = destroyedSprite;
		if(GetComponent<Collider2D>() != null) {
			GetComponent<Collider2D>().enabled = false;
		}
		Instantiate(destroyedEffects, transform.position, Quaternion.identity);
		BroadcastMessage("OnLootDrop", SendMessageOptions.DontRequireReceiver);
	}
}
