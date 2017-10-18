using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITouchControl : MonoBehaviour {

	public GameObject up;
	public GameObject down;
	public GameObject right;
	public GameObject left;
	public GameObject a;
	public GameObject b;

	private CharacterTouchControl touchControl;

	void Awake() {
	}

	void Start() {
		SetMovementListener();
		SetActionListener();
		touchControl = FindObjectOfType<CharacterTouchControl>();
	}

	public void SetMovementListener() {
		EventTrigger upTrigger = up.GetComponent<EventTrigger>();
		EventTrigger.Entry upEntry = new EventTrigger.Entry();
		upEntry.eventID = EventTriggerType.PointerEnter;
		upEntry.callback.AddListener((data) => {
			WalkUp((PointerEventData) data);
		});
		EventTrigger.Entry upExit = new EventTrigger.Entry();
		upExit.eventID = EventTriggerType.PointerExit;
		upExit.callback.AddListener((data) => {
			ReleaseWalk((PointerEventData) data);
		});
		upTrigger.triggers.Add(upEntry);
		upTrigger.triggers.Add(upExit);

		EventTrigger downTrigger = down.GetComponent<EventTrigger>();
		EventTrigger.Entry downEntry = new EventTrigger.Entry();
		downEntry.eventID = EventTriggerType.PointerEnter;
		downEntry.callback.AddListener((data) => {
			WalkDown((PointerEventData) data);
		});
		EventTrigger.Entry downExit = new EventTrigger.Entry();
		downExit.eventID = EventTriggerType.PointerExit;
		downExit.callback.AddListener((data) => {
			ReleaseWalk((PointerEventData) data);
		});
		downTrigger.triggers.Add(downEntry);
		downTrigger.triggers.Add(downExit);

		EventTrigger leftTrigger = left.GetComponent<EventTrigger>();
		EventTrigger.Entry leftEntry = new EventTrigger.Entry();
		leftEntry.eventID = EventTriggerType.PointerEnter;
		leftEntry.callback.AddListener((data) => {
			WalkLeft((PointerEventData) data);
		});
		EventTrigger.Entry leftExit = new EventTrigger.Entry();
		leftExit.eventID = EventTriggerType.PointerExit;
		leftExit.callback.AddListener((data) => {
			ReleaseWalk((PointerEventData) data);
		});
		leftTrigger.triggers.Add(leftEntry);
		leftTrigger.triggers.Add(leftExit);

		EventTrigger rightTrigger = right.GetComponent<EventTrigger>();
		EventTrigger.Entry rightEntry = new EventTrigger.Entry();
		rightEntry.eventID = EventTriggerType.PointerEnter;
		rightEntry.callback.AddListener((data) => {
			WalkRight((PointerEventData) data);
		});
		EventTrigger.Entry rightExit = new EventTrigger.Entry();
		rightExit.eventID = EventTriggerType.PointerExit;
		rightExit.callback.AddListener((data) => {
			ReleaseWalk((PointerEventData) data);
		});
		rightTrigger.triggers.Add(rightEntry);
		rightTrigger.triggers.Add(rightExit);
	}
	

	public void SetActionListener() {
		EventTrigger aTrigger = a.GetComponent<EventTrigger>();
		EventTrigger.Entry aEntry = new EventTrigger.Entry();
		aEntry.eventID = EventTriggerType.PointerDown;
		aEntry.callback.AddListener((data) => {
			A((PointerEventData) data);
		});
		aTrigger.triggers.Add(aEntry);

		EventTrigger bTrigger = b.GetComponent<EventTrigger>();
		EventTrigger.Entry bEntry = new EventTrigger.Entry();
		bEntry.eventID = EventTriggerType.PointerDown;
		bEntry.callback.AddListener((data) => {
			B((PointerEventData) data);
		});
		bTrigger.triggers.Add(bEntry);
	}

	public void WalkUp(PointerEventData data) {
		Debug.Log("Up");
		touchControl.WalkUp();
	}

	public void WalkDown(PointerEventData data) {
		Debug.Log("Down");
		touchControl.WalkDown();
	}

	public void WalkLeft(PointerEventData data) {
		Debug.Log("Left");
		touchControl.WalkLeft();
	}

	public void WalkRight(PointerEventData data) {
		Debug.Log("Left");
		touchControl.WalkRight();
	}

	public void ReleaseWalk(PointerEventData data) {
		touchControl.ReleaseWalk();
	}

	public void A(PointerEventData data) {
		touchControl.UpdateAttack();
	}

	public void B(PointerEventData data) {
		touchControl.UpdateAction();
	}
}
