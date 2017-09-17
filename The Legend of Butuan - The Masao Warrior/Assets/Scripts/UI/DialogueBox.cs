using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueBox : MonoBehaviour {

	public static DialogueBox instance;
	private Text dialogueText;
	private Image avatar;
	private GameObject button;
	private GameObject touchControls;

	void Awake() {
		instance = this;
		dialogueText = GetComponentsInChildren<Text>()[1];
		avatar = GetComponentsInChildren<Image>()[3];
		button = GetComponentInChildren<Button>().gameObject;
		touchControls = GameObject.FindGameObjectWithTag("TouchControls");
	}

	void Start() {
		Hide();
		HideButton();
	}

	public static void SetText(string sentence) {
		instance.dialogueText.text = sentence;
	}

	public static string GetText() {
		return instance.dialogueText.text;
	}

	public static void SetAvatar(Sprite avatar) {
		instance.avatar.sprite = avatar;
	}
	
	public static void Show() {
		instance.DoShow();
	}

	public static void Hide() {
		instance.DoHide();
	}

	public static bool IsVisible() {
		return instance.enabled;
	}

	void DoShow() {
		if(touchControls != null) {
			touchControls.SetActive(false);
		}
		gameObject.SetActive(true);
	}

	void DoHide() {
		if(touchControls != null) {
			touchControls.SetActive(true);
		}
		gameObject.SetActive(false);
	}

	public static void ShowNextButton(string text) {
		instance.button.GetComponentInChildren<Text>().text = text;
		instance.button.SetActive(true);
	}

	public static void HideButton() {
		instance.button.GetComponentInChildren<Text>().text = "";
		instance.button.SetActive(false);
	}
}
