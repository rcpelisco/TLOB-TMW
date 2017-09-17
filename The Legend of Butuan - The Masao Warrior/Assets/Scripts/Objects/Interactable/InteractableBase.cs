using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableBase : MonoBehaviour {
	virtual public void OnInteract(Character character) {
		Debug.Log("OnInteract is not implemented");
	}

	virtual public void OnInteractRelease() {
		Debug.Log("OnInteractRelease is not implemented");
	}
}
