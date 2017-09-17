using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterInteractionModel : MonoBehaviour {

	private Character character;
	private CharacterMovementModel movementModel;
	private InteractableBase foundInteractable;

	void Awake() {
		character = GetComponent<Character>();
		movementModel = GetComponent<CharacterMovementModel>();
	}

	void FixedUpdate() {
	}

	void Update() {
	}

	public void OnInteract() {
		foundInteractable = FindUsableInteractable();
		if(foundInteractable == null) {
			return;
		}
		foundInteractable.OnInteract(character);
	}

	public void OnInteractRelease() {
		foundInteractable.OnInteractRelease();
	}

	InteractableBase FindUsableInteractable() {
		Collider2D[] closeColliders = Physics2D.OverlapCircleAll(transform.position, 0.8f);
		InteractableBase closestInteractable = null;
		float angleToClosestInteractable = Mathf.Infinity;
		for(int i = 0; i < closeColliders.Length; i++) {
			InteractableBase colliderInteractable = closeColliders[i].GetComponent<InteractableBase>();
			if(colliderInteractable == null) {
				continue;
			}
			Vector3 directionToInteractable = closeColliders[i].transform.position - transform.position;
			float angleToInteractable = Vector3.Angle(movementModel.GetFacingDirection(), directionToInteractable);
			if(angleToInteractable < 40) {
				if(angleToInteractable < angleToClosestInteractable) {
					closestInteractable = colliderInteractable;
					angleToClosestInteractable = angleToInteractable;
				}
			}
		}
		return closestInteractable;
	}
}
