using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sign : MonoBehaviour {
	public enum SignDirection {
		UpRight, UpLeft,
		DownRight, DownLeft,
		Left,Right
	}

	public SignDirection direction;
	public string text;
	public Sprite upRight;
	public Sprite upLeft;
	public Sprite downRight;
	public Sprite downLeft;
	public Sprite left;
	public Sprite right;

	private Animator signAnim;
	private Image signSprite;
	private Text signText;

	void Awake() {
		signAnim = GetComponentInChildren<Animator>();
		signSprite = GetComponentInChildren<Image>();
		signText = GetComponentInChildren<Text>();
		signText.text = text;
		SetDirection();
	}

	void SetDirection() {
		if(direction == SignDirection.UpLeft) {
			signAnim.SetFloat("y", 1f);
			signSprite.sprite = upLeft;
		} else if(direction == SignDirection.UpRight) {
			signAnim.SetFloat("y", 1f);
			signSprite.sprite = upRight;
		} else if(direction == SignDirection.DownLeft) {
			signAnim.SetFloat("y", -1f);
			signSprite.sprite = downLeft;
		} else if(direction == SignDirection.DownRight) {
			signAnim.SetFloat("y", -1f);
			signSprite.sprite = downRight;
		} else if(direction == SignDirection.Left) {
			signAnim.SetFloat("x", -1f);
			signSprite.sprite = left;
		} else if(direction == SignDirection.Right) {
			signAnim.SetFloat("x", 1f);
			signSprite.sprite = right;
		}
	}
}
