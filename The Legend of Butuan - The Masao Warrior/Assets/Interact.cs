using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

	private CharacterInteractionModel interactionModel;

	void Awake() {
		interactionModel = GameObject.Find("Player").GetComponent<CharacterInteractionModel>();
	}
	

	void OnEnable() {
		interactionModel.OnInteract();
	}
}
