using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementView : MonoBehaviour {
	
	public Animator animator;
	public Transform weaponParent;
	public Transform shieldParent;

	private CharacterMovementModel movementModel;
	private CharacterHealthModel healthModel;

	void Awake() {
		if(animator == null) {
			Debug.Log("Animator is not added!");
			enabled = false;
		}
		movementModel = GetComponent<CharacterMovementModel>();
		healthModel = GetComponent<CharacterHealthModel>();
	}

	void Start() {
		SetWeaponActive(false);
	}

	void Update() {
		if(healthModel != null) {
			if(healthModel.GetHealth() <= 0) {
				return;
			}
		}
		UpdateDirection();
		UpdatePickUpAnimation();
		UpdateHit();
	}

	public void OnDeath() {
		animator.SetTrigger("isDead");
	}

	void UpdateHit() {
		animator.SetBool("isHit", movementModel.IsBeingPushed());
	}

	void UpdateDirection() {
		Vector3 direction = movementModel.GetDirection();
		if(direction != Vector3.zero) {
			animator.SetFloat("x", direction.x);
			animator.SetFloat("y", direction.y);
		}
		animator.SetBool("isWalking", movementModel.IsMoving());
	}

	void UpdatePickUpAnimation() {
		if(movementModel.weaponParent == null) {
			return;
		}
		bool isPickingOneHanded = false;
		bool isPickingTwoHanded = false;
		if(movementModel.IsFrozen()) {
			ItemType pickupItem =  movementModel.GetItemPickedUp();
			if(pickupItem != ItemType.None) {
				ItemData itemData = Database.item.FindItem(pickupItem);
				switch(itemData.animation) {
					case ItemData.PickupAnimation.OneHanded:
						isPickingOneHanded = true;
						break;
					case ItemData.PickupAnimation.TwoHanded:
						isPickingTwoHanded = true;
						break;
				}
			}
		}
		animator.SetBool("isPickingOneHanded", isPickingOneHanded);
		animator.SetBool("isPickingTwoHanded", isPickingTwoHanded);
	}

	public void DoAttack() {
		if(movementModel.canAttack) {
			animator.SetTrigger("doAttack");
		}
	}

	public void OnAttackStarted() {
	}

	public void OnAttackFinished() {

	}

	public void ShowWeapon() {
		SetWeaponActive(true);
	}

	public void HideWeapon() {
		SetWeaponActive(false);
	}

	public void ShowShield() {
		SetShieldActive(true);
	}

	public void HideShield() {
		SetShieldActive(false);
	}

	void SetWeaponActive(bool doActivate) {
		if(weaponParent != null) {
			weaponParent.gameObject.SetActive(doActivate);
		}
	}

	void SetShieldActive(bool doActivate) {
		if(shieldParent != null) {
			shieldParent.gameObject.SetActive(doActivate);
		}
	}

	public void SetWeaponSortingOrder(int sortingOrder) {
		if(weaponParent == null) {
			return;
		}
		SpriteRenderer[] spriteRenderers = weaponParent.GetComponentsInChildren<SpriteRenderer>();
		foreach(SpriteRenderer spriteRenderer in spriteRenderers) {
			spriteRenderer.sortingOrder = sortingOrder;

		}
	}
}
